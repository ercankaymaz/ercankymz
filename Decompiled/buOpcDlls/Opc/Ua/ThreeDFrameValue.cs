using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ThreeDFrameValue : BaseVariableValue
{
	private ThreeDFrame m_value;

	private ThreeDFrameState m_variable;

	public ThreeDFrameState Variable => m_variable;

	public ThreeDFrame Value
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

	public ThreeDFrameValue(ThreeDFrameState variable, ThreeDFrame value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new ThreeDFrame();
		}
		Initialize(variable);
	}

	private void Initialize(ThreeDFrameState variable)
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
			baseVariableState = m_variable.CartesianCoordinates;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_CartesianCoordinates;
				baseVariableState.OnWriteValue = OnWrite_CartesianCoordinates;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Orientation;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Orientation;
				baseVariableState.OnWriteValue = OnWrite_Orientation;
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
			ThreeDFrame newValue = ((!(value is ExtensionObject extensionObject)) ? ((ThreeDFrame)value) : ((ThreeDFrame)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (ThreeDFrame)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref ThreeDFrame newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.CartesianCoordinates, newValue.CartesianCoordinates))
		{
			UpdateChildVariableStatus(m_variable.CartesianCoordinates, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Orientation, newValue.Orientation))
		{
			UpdateChildVariableStatus(m_variable.Orientation, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_CartesianCoordinates(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			ThreeDCartesianCoordinatesState threeDCartesianCoordinatesState = m_variable?.CartesianCoordinates;
			if (threeDCartesianCoordinatesState != null && StatusCode.IsBad(threeDCartesianCoordinatesState.StatusCode))
			{
				value = null;
				statusCode = threeDCartesianCoordinatesState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.CartesianCoordinates;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (threeDCartesianCoordinatesState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = threeDCartesianCoordinatesState.Timestamp;
				if (statusCode != threeDCartesianCoordinatesState.StatusCode)
				{
					statusCode = threeDCartesianCoordinatesState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_CartesianCoordinates(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.CartesianCoordinates, ref statusCode, ref timestamp);
			m_value.CartesianCoordinates = (ThreeDCartesianCoordinates)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Orientation(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			ThreeDOrientationState threeDOrientationState = m_variable?.Orientation;
			if (threeDOrientationState != null && StatusCode.IsBad(threeDOrientationState.StatusCode))
			{
				value = null;
				statusCode = threeDOrientationState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Orientation;
			}
			ServiceResult serviceResult = Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
			if (threeDOrientationState != null && ServiceResult.IsNotBad(serviceResult))
			{
				timestamp = threeDOrientationState.Timestamp;
				if (statusCode != threeDOrientationState.StatusCode)
				{
					statusCode = threeDOrientationState.StatusCode;
					serviceResult = new ServiceResult(statusCode);
				}
			}
			return serviceResult;
		}
	}

	private ServiceResult OnWrite_Orientation(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Orientation, ref statusCode, ref timestamp);
			m_value.Orientation = (ThreeDOrientation)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
