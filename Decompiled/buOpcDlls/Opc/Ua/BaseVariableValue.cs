using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseVariableValue
{
	public VariableValueEventHandler OnBeforeRead;

	public VariableValueEventHandler OnAfterWrite;

	private object m_lock;

	private VariableCopyPolicy m_copyPolicy;

	private BaseInstanceState[] m_updateList;

	private ServiceResult m_error;

	private DateTime m_timestamp;

	public object Lock => m_lock;

	public VariableCopyPolicy CopyPolicy
	{
		get
		{
			return m_copyPolicy;
		}
		set
		{
			m_copyPolicy = value;
		}
	}

	public ServiceResult Error
	{
		get
		{
			return m_error;
		}
		set
		{
			m_error = value;
		}
	}

	public DateTime Timestamp
	{
		get
		{
			return m_timestamp;
		}
		set
		{
			m_timestamp = value;
		}
	}

	public BaseVariableValue(object dataLock)
	{
		m_lock = dataLock;
		m_copyPolicy = VariableCopyPolicy.CopyOnRead;
		if (m_lock == null)
		{
			m_lock = new object();
		}
	}

	public void ChangesComplete(ISystemContext context)
	{
		lock (m_lock)
		{
			if (m_updateList == null)
			{
				return;
			}
			for (int i = 0; i < m_updateList.Length; i++)
			{
				BaseInstanceState baseInstanceState = m_updateList[i];
				if (baseInstanceState != null)
				{
					baseInstanceState.UpdateChangeMasks(NodeStateChangeMasks.Value);
					baseInstanceState.ClearChangeMasks(context, includeChildren: false);
				}
			}
		}
	}

	protected void DoBeforeReadProcessing(ISystemContext context, NodeState node)
	{
		if (OnBeforeRead != null)
		{
			OnBeforeRead(context, this, node);
		}
	}

	protected ServiceResult Read(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (m_lock)
		{
			if (m_timestamp == DateTime.MinValue)
			{
				m_timestamp = DateTime.UtcNow;
			}
			timestamp = m_timestamp;
			if (ServiceResult.IsBad(m_error))
			{
				value = null;
				statusCode = m_error.StatusCode;
				return m_error;
			}
			ServiceResult serviceResult = BaseVariableState.ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
			if (ServiceResult.IsBad(serviceResult))
			{
				statusCode = serviceResult.StatusCode;
				return serviceResult;
			}
			if ((m_copyPolicy & VariableCopyPolicy.CopyOnRead) != VariableCopyPolicy.Never)
			{
				value = Utils.Clone(value);
			}
			statusCode = 0u;
			return ServiceResult.Good;
		}
	}

	protected ServiceResult Read(object currentValue, ref object valueToRead)
	{
		lock (m_lock)
		{
			if (ServiceResult.IsBad(m_error))
			{
				valueToRead = null;
				return m_error;
			}
			if ((m_copyPolicy & VariableCopyPolicy.CopyOnRead) != VariableCopyPolicy.Never)
			{
				valueToRead = Utils.Clone(currentValue);
			}
			else
			{
				valueToRead = currentValue;
			}
			return ServiceResult.Good;
		}
	}

	protected object Write(object valueToWrite)
	{
		lock (m_lock)
		{
			if ((m_copyPolicy & VariableCopyPolicy.CopyOnWrite) != VariableCopyPolicy.Never)
			{
				return Utils.Clone(valueToWrite);
			}
			return valueToWrite;
		}
	}

	protected void SetUpdateList(IList<BaseInstanceState> updateList)
	{
		lock (m_lock)
		{
			m_updateList = null;
			if (updateList == null || updateList.Count <= 0)
			{
				return;
			}
			m_updateList = new BaseInstanceState[updateList.Count];
			for (int i = 0; i < m_updateList.Length; i++)
			{
				m_updateList[i] = updateList[i];
				if (m_updateList[i] is BaseVariableState baseVariableState)
				{
					baseVariableState.CopyPolicy = VariableCopyPolicy.Never;
				}
			}
		}
	}
}
