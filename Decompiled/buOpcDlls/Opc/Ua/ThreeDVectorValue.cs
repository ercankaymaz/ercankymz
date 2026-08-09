using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ThreeDVectorValue : BaseVariableValue
{
	private ThreeDVector m_value;

	private ThreeDVectorState m_variable;

	public ThreeDVectorState Variable => m_variable;

	public ThreeDVector Value
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

	public ThreeDVectorValue(ThreeDVectorState variable, ThreeDVector value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new ThreeDVector();
		}
		Initialize(variable);
	}

	private void Initialize(ThreeDVectorState variable)
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
			baseVariableState = m_variable.X;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_X;
				baseVariableState.OnWriteValue = OnWrite_X;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Y;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Y;
				baseVariableState.OnWriteValue = OnWrite_Y;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Z;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Z;
				baseVariableState.OnWriteValue = OnWrite_Z;
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
			ThreeDVector newValue = ((!(value is ExtensionObject extensionObject)) ? ((ThreeDVector)value) : ((ThreeDVector)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (ThreeDVector)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref ThreeDVector newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.X, newValue.X))
		{
			UpdateChildVariableStatus(m_variable.X, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Y, newValue.Y))
		{
			UpdateChildVariableStatus(m_variable.Y, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Z, newValue.Z))
		{
			UpdateChildVariableStatus(m_variable.Z, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_X(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<double> baseDataVariableState = m_variable?.X;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.X;
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

	private ServiceResult OnWrite_X(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.X, ref statusCode, ref timestamp);
			m_value.X = (double)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Y(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<double> baseDataVariableState = m_variable?.Y;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Y;
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

	private ServiceResult OnWrite_Y(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Y, ref statusCode, ref timestamp);
			m_value.Y = (double)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Z(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<double> baseDataVariableState = m_variable?.Z;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Z;
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

	private ServiceResult OnWrite_Z(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Z, ref statusCode, ref timestamp);
			m_value.Z = (double)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
