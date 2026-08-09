using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramDiagnosticValue : BaseVariableValue
{
	private ProgramDiagnosticDataType m_value;

	private ProgramDiagnosticState m_variable;

	public ProgramDiagnosticState Variable => m_variable;

	public ProgramDiagnosticDataType Value
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

	public ProgramDiagnosticValue(ProgramDiagnosticState variable, ProgramDiagnosticDataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new ProgramDiagnosticDataType();
		}
		Initialize(variable);
	}

	private void Initialize(ProgramDiagnosticState variable)
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
			baseVariableState = m_variable.CreateSessionId;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CreateSessionId;
				baseVariableState.OnWriteValue = OnWrite_CreateSessionId;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.CreateClientName;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CreateClientName;
				baseVariableState.OnWriteValue = OnWrite_CreateClientName;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.InvocationCreationTime;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_InvocationCreationTime;
				baseVariableState.OnWriteValue = OnWrite_InvocationCreationTime;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastTransitionTime;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastTransitionTime;
				baseVariableState.OnWriteValue = OnWrite_LastTransitionTime;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodCall;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodCall;
				baseVariableState.OnWriteValue = OnWrite_LastMethodCall;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodSessionId;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodSessionId;
				baseVariableState.OnWriteValue = OnWrite_LastMethodSessionId;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodInputArguments;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodInputArguments;
				baseVariableState.OnWriteValue = OnWrite_LastMethodInputArguments;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodOutputArguments;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodOutputArguments;
				baseVariableState.OnWriteValue = OnWrite_LastMethodOutputArguments;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodCallTime;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodCallTime;
				baseVariableState.OnWriteValue = OnWrite_LastMethodCallTime;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodReturnStatus;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodReturnStatus;
				baseVariableState.OnWriteValue = OnWrite_LastMethodReturnStatus;
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
			ProgramDiagnosticDataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((ProgramDiagnosticDataType)value) : ((ProgramDiagnosticDataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (ProgramDiagnosticDataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref ProgramDiagnosticDataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.CreateSessionId, newValue.CreateSessionId))
		{
			UpdateChildVariableStatus(m_variable.CreateSessionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.CreateClientName, newValue.CreateClientName))
		{
			UpdateChildVariableStatus(m_variable.CreateClientName, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.InvocationCreationTime, newValue.InvocationCreationTime))
		{
			UpdateChildVariableStatus(m_variable.InvocationCreationTime, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastTransitionTime, newValue.LastTransitionTime))
		{
			UpdateChildVariableStatus(m_variable.LastTransitionTime, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodCall, newValue.LastMethodCall))
		{
			UpdateChildVariableStatus(m_variable.LastMethodCall, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodSessionId, newValue.LastMethodSessionId))
		{
			UpdateChildVariableStatus(m_variable.LastMethodSessionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodInputArguments, newValue.LastMethodInputArguments))
		{
			UpdateChildVariableStatus(m_variable.LastMethodInputArguments, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodOutputArguments, newValue.LastMethodOutputArguments))
		{
			UpdateChildVariableStatus(m_variable.LastMethodOutputArguments, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodCallTime, newValue.LastMethodCallTime))
		{
			UpdateChildVariableStatus(m_variable.LastMethodCallTime, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodReturnStatus, newValue.LastMethodReturnStatus))
		{
			UpdateChildVariableStatus(m_variable.LastMethodReturnStatus, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_CreateSessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<NodeId> propertyState = m_variable?.CreateSessionId;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateSessionId;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CreateSessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CreateSessionId, ref statusCode, ref timestamp);
			m_value.CreateSessionId = (NodeId)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_CreateClientName(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<string> propertyState = m_variable?.CreateClientName;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateClientName;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CreateClientName(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CreateClientName, ref statusCode, ref timestamp);
			m_value.CreateClientName = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_InvocationCreationTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<DateTime> propertyState = m_variable?.InvocationCreationTime;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.InvocationCreationTime;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_InvocationCreationTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.InvocationCreationTime, ref statusCode, ref timestamp);
			m_value.InvocationCreationTime = (DateTime)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastTransitionTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<DateTime> propertyState = m_variable?.LastTransitionTime;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastTransitionTime;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastTransitionTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastTransitionTime, ref statusCode, ref timestamp);
			m_value.LastTransitionTime = (DateTime)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodCall(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<string> propertyState = m_variable?.LastMethodCall;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodCall;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodCall(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodCall, ref statusCode, ref timestamp);
			m_value.LastMethodCall = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodSessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<NodeId> propertyState = m_variable?.LastMethodSessionId;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodSessionId;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodSessionId(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodSessionId, ref statusCode, ref timestamp);
			m_value.LastMethodSessionId = (NodeId)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodInputArguments(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<object[]> propertyState = m_variable?.LastMethodInputArguments;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodInputArguments;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodInputArguments(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodInputArguments, ref statusCode, ref timestamp);
			m_value.LastMethodInputArguments = (ArgumentCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodOutputArguments(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<object[]> propertyState = m_variable?.LastMethodOutputArguments;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodOutputArguments;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodOutputArguments(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodOutputArguments, ref statusCode, ref timestamp);
			m_value.LastMethodOutputArguments = (ArgumentCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodCallTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<DateTime> propertyState = m_variable?.LastMethodCallTime;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodCallTime;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodCallTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodCallTime, ref statusCode, ref timestamp);
			m_value.LastMethodCallTime = (DateTime)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodReturnStatus(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			PropertyState<StatusResult> propertyState = m_variable?.LastMethodReturnStatus;
			if (propertyState != null && StatusCode.IsBad(propertyState.StatusCode))
			{
				value = null;
				statusCode = propertyState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodReturnStatus;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (propertyState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = propertyState.Timestamp;
				if (statusCode != propertyState.StatusCode)
				{
					statusCode = propertyState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_LastMethodReturnStatus(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodReturnStatus, ref statusCode, ref timestamp);
			m_value.LastMethodReturnStatus = (StatusResult)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
