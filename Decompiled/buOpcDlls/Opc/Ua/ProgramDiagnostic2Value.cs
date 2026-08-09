using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramDiagnostic2Value : BaseVariableValue
{
	private ProgramDiagnostic2DataType m_value;

	private ProgramDiagnostic2State m_variable;

	public ProgramDiagnostic2State Variable => m_variable;

	public ProgramDiagnostic2DataType Value
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

	public ProgramDiagnostic2Value(ProgramDiagnostic2State variable, ProgramDiagnostic2DataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new ProgramDiagnostic2DataType();
		}
		Initialize(variable);
	}

	private void Initialize(ProgramDiagnostic2State variable)
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
			baseVariableState = m_variable.LastMethodInputValues;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodInputValues;
				baseVariableState.OnWriteValue = OnWrite_LastMethodInputValues;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.LastMethodOutputValues;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_LastMethodOutputValues;
				baseVariableState.OnWriteValue = OnWrite_LastMethodOutputValues;
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
			ProgramDiagnostic2DataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((ProgramDiagnostic2DataType)value) : ((ProgramDiagnostic2DataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (ProgramDiagnostic2DataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref ProgramDiagnostic2DataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
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
		if (!Utils.IsEqual(m_value.LastMethodInputValues, newValue.LastMethodInputValues))
		{
			UpdateChildVariableStatus(m_variable.LastMethodInputValues, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.LastMethodOutputValues, newValue.LastMethodOutputValues))
		{
			UpdateChildVariableStatus(m_variable.LastMethodOutputValues, ref statusCode, ref timestamp);
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
			BaseDataVariableState<NodeId> baseDataVariableState = m_variable?.CreateSessionId;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateSessionId;
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
			BaseDataVariableState<string> baseDataVariableState = m_variable?.CreateClientName;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CreateClientName;
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
			BaseDataVariableState<DateTime> baseDataVariableState = m_variable?.InvocationCreationTime;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.InvocationCreationTime;
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
			BaseDataVariableState<string> baseDataVariableState = m_variable?.LastMethodCall;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodCall;
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
			BaseDataVariableState<NodeId> baseDataVariableState = m_variable?.LastMethodSessionId;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodSessionId;
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
			BaseDataVariableState<Argument[]> baseDataVariableState = m_variable?.LastMethodInputArguments;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodInputArguments;
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
			BaseDataVariableState<Argument[]> baseDataVariableState = m_variable?.LastMethodOutputArguments;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodOutputArguments;
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

	private ServiceResult OnRead_LastMethodInputValues(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<object[]> baseDataVariableState = m_variable?.LastMethodInputValues;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodInputValues;
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

	private ServiceResult OnWrite_LastMethodInputValues(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodInputValues, ref statusCode, ref timestamp);
			m_value.LastMethodInputValues = (VariantCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodOutputValues(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<object[]> baseDataVariableState = m_variable?.LastMethodOutputValues;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodOutputValues;
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

	private ServiceResult OnWrite_LastMethodOutputValues(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodOutputValues, ref statusCode, ref timestamp);
			m_value.LastMethodOutputValues = (VariantCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_LastMethodCallTime(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<DateTime> baseDataVariableState = m_variable?.LastMethodCallTime;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodCallTime;
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
			BaseDataVariableState<StatusCode> baseDataVariableState = m_variable?.LastMethodReturnStatus;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.LastMethodReturnStatus;
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

	private ServiceResult OnWrite_LastMethodReturnStatus(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.LastMethodReturnStatus, ref statusCode, ref timestamp);
			m_value.LastMethodReturnStatus = (StatusCode)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
