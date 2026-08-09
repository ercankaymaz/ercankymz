using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsValue : BaseVariableValue
{
	private SessionSecurityDiagnosticsDataType m_value;

	private SessionSecurityDiagnosticsState m_variable;

	public SessionSecurityDiagnosticsState Variable => m_variable;

	public SessionSecurityDiagnosticsDataType Value
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

	public SessionSecurityDiagnosticsValue(SessionSecurityDiagnosticsState variable, SessionSecurityDiagnosticsDataType value, object dataLock)
		: base(dataLock)
	{
		m_value = value;
		if (m_value == null)
		{
			m_value = new SessionSecurityDiagnosticsDataType();
		}
		Initialize(variable);
	}

	private void Initialize(SessionSecurityDiagnosticsState variable)
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
			baseVariableState = m_variable.ClientUserIdOfSession;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientUserIdOfSession;
				baseVariableState.OnWriteValue = OnWrite_ClientUserIdOfSession;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ClientUserIdHistory;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientUserIdHistory;
				baseVariableState.OnWriteValue = OnWrite_ClientUserIdHistory;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.AuthenticationMechanism;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_AuthenticationMechanism;
				baseVariableState.OnWriteValue = OnWrite_AuthenticationMechanism;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.Encoding;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_Encoding;
				baseVariableState.OnWriteValue = OnWrite_Encoding;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.TransportProtocol;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_TransportProtocol;
				baseVariableState.OnWriteValue = OnWrite_TransportProtocol;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SecurityMode;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SecurityMode;
				baseVariableState.OnWriteValue = OnWrite_SecurityMode;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.SecurityPolicyUri;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_SecurityPolicyUri;
				baseVariableState.OnWriteValue = OnWrite_SecurityPolicyUri;
				list.Add(baseVariableState);
			}
			baseVariableState = m_variable.ClientCertificate;
			if (baseVariableState != null)
			{
				baseVariableState.OnReadValue = OnRead_ClientCertificate;
				baseVariableState.OnWriteValue = OnWrite_ClientCertificate;
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
			SessionSecurityDiagnosticsDataType newValue = ((!(value is ExtensionObject extensionObject)) ? ((SessionSecurityDiagnosticsDataType)value) : ((SessionSecurityDiagnosticsDataType)extensionObject.Body));
			if (!Utils.IsEqual(m_value, newValue))
			{
				UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
				base.Timestamp = timestamp;
				m_value = (SessionSecurityDiagnosticsDataType)Write(newValue);
				m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
			}
		}
		return ServiceResult.Good;
	}

	private void UpdateChildrenChangeMasks(ISystemContext context, ref SessionSecurityDiagnosticsDataType newValue, ref StatusCode statusCode, ref DateTime timestamp)
	{
		if (!Utils.IsEqual(m_value.SessionId, newValue.SessionId))
		{
			UpdateChildVariableStatus(m_variable.SessionId, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientUserIdOfSession, newValue.ClientUserIdOfSession))
		{
			UpdateChildVariableStatus(m_variable.ClientUserIdOfSession, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientUserIdHistory, newValue.ClientUserIdHistory))
		{
			UpdateChildVariableStatus(m_variable.ClientUserIdHistory, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.AuthenticationMechanism, newValue.AuthenticationMechanism))
		{
			UpdateChildVariableStatus(m_variable.AuthenticationMechanism, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.Encoding, newValue.Encoding))
		{
			UpdateChildVariableStatus(m_variable.Encoding, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.TransportProtocol, newValue.TransportProtocol))
		{
			UpdateChildVariableStatus(m_variable.TransportProtocol, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SecurityMode, newValue.SecurityMode))
		{
			UpdateChildVariableStatus(m_variable.SecurityMode, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.SecurityPolicyUri, newValue.SecurityPolicyUri))
		{
			UpdateChildVariableStatus(m_variable.SecurityPolicyUri, ref statusCode, ref timestamp);
		}
		if (!Utils.IsEqual(m_value.ClientCertificate, newValue.ClientCertificate))
		{
			UpdateChildVariableStatus(m_variable.ClientCertificate, ref statusCode, ref timestamp);
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

	private ServiceResult OnRead_ClientUserIdOfSession(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.ClientUserIdOfSession;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientUserIdOfSession;
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

	private ServiceResult OnWrite_ClientUserIdOfSession(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientUserIdOfSession, ref statusCode, ref timestamp);
			m_value.ClientUserIdOfSession = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ClientUserIdHistory(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string[]> baseDataVariableState = m_variable?.ClientUserIdHistory;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientUserIdHistory;
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

	private ServiceResult OnWrite_ClientUserIdHistory(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientUserIdHistory, ref statusCode, ref timestamp);
			m_value.ClientUserIdHistory = (StringCollection)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_AuthenticationMechanism(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.AuthenticationMechanism;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.AuthenticationMechanism;
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

	private ServiceResult OnWrite_AuthenticationMechanism(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.AuthenticationMechanism, ref statusCode, ref timestamp);
			m_value.AuthenticationMechanism = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_Encoding(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.Encoding;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.Encoding;
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

	private ServiceResult OnWrite_Encoding(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.Encoding, ref statusCode, ref timestamp);
			m_value.Encoding = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_TransportProtocol(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.TransportProtocol;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.TransportProtocol;
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

	private ServiceResult OnWrite_TransportProtocol(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.TransportProtocol, ref statusCode, ref timestamp);
			m_value.TransportProtocol = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SecurityMode(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<MessageSecurityMode> baseDataVariableState = m_variable?.SecurityMode;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SecurityMode;
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

	private ServiceResult OnWrite_SecurityMode(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SecurityMode, ref statusCode, ref timestamp);
			m_value.SecurityMode = (MessageSecurityMode)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_SecurityPolicyUri(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<string> baseDataVariableState = m_variable?.SecurityPolicyUri;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.SecurityPolicyUri;
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

	private ServiceResult OnWrite_SecurityPolicyUri(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.SecurityPolicyUri, ref statusCode, ref timestamp);
			m_value.SecurityPolicyUri = (string)Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}

	private ServiceResult OnRead_ClientCertificate(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			DoBeforeReadProcessing(context, node);
			BaseDataVariableState<byte[]> baseDataVariableState = m_variable?.ClientCertificate;
			if (baseDataVariableState != null && StatusCode.IsBad(baseDataVariableState.StatusCode))
			{
				value = null;
				statusCode = baseDataVariableState.StatusCode;
				return new ServiceResult(statusCode);
			}
			if (m_value != null)
			{
				value = m_value.ClientCertificate;
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

	private ServiceResult OnWrite_ClientCertificate(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
	{
		lock (base.Lock)
		{
			UpdateChildVariableStatus(m_variable.ClientCertificate, ref statusCode, ref timestamp);
			m_value.ClientCertificate = (byte[])Write(value);
			UpdateParent(context, ref statusCode, ref timestamp);
		}
		return ServiceResult.Good;
	}
}
