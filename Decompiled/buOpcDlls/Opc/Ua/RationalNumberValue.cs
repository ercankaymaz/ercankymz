using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RationalNumberValue : BaseVariableValue
{
	private RationalNumber m_value;

	private RationalNumberState m_variable;

	public RationalNumberState Variable => m_variable;

	public RationalNumber Value
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

	public RationalNumberValue(RationalNumberState variable, RationalNumber value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new RationalNumber();
		}
		Initialize(variable);
	}

	private void Initialize(RationalNumberState variable)
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
			baseVariableState = m_variable.Numerator;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Numerator;
				baseVariableState.OnWriteValue = OnWrite_Numerator;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Denominator;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Denominator;
				baseVariableState.OnWriteValue = OnWrite_Denominator;
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
			RationalNumber newValue = ((!(value is ExtensionObject extensionObject)) ? ((RationalNumber)value) : ((RationalNumber)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (RationalNumber)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref RationalNumber newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.Numerator, newValue.Numerator))
		{
			UpdateChildVariableStatus(m_variable.Numerator, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Denominator, newValue.Denominator))
		{
			UpdateChildVariableStatus(m_variable.Denominator, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_Numerator(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<int> baseDataVariableState = m_variable?.Numerator;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Numerator;
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

	private ServiceResult OnWrite_Numerator(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Numerator, ref statusCode, ref timestamp);
			m_value.Numerator = (int)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Denominator(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<uint> baseDataVariableState = m_variable?.Denominator;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Denominator;
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

	private ServiceResult OnWrite_Denominator(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Denominator, ref statusCode, ref timestamp);
			m_value.Denominator = (uint)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
