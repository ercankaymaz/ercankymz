// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionSecurityDiagnosticsValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsValue : BaseVariableValue
{
  private SessionSecurityDiagnosticsDataType m_value;
  private SessionSecurityDiagnosticsState m_variable;

  public SessionSecurityDiagnosticsValue(
    SessionSecurityDiagnosticsState variable,
    SessionSecurityDiagnosticsDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new SessionSecurityDiagnosticsDataType();
    this.Initialize(variable);
  }

  public SessionSecurityDiagnosticsState Variable => this.m_variable;

  public SessionSecurityDiagnosticsDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(SessionSecurityDiagnosticsState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState sessionId = (BaseVariableState) this.m_variable.SessionId;
      if (sessionId != null)
      {
        sessionId.OnReadValue = new NodeValueEventHandler(this.OnRead_SessionId);
        sessionId.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SessionId);
        updateList.Add((BaseInstanceState) sessionId);
      }
      BaseVariableState clientUserIdOfSession = (BaseVariableState) this.m_variable.ClientUserIdOfSession;
      if (clientUserIdOfSession != null)
      {
        clientUserIdOfSession.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientUserIdOfSession);
        clientUserIdOfSession.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientUserIdOfSession);
        updateList.Add((BaseInstanceState) clientUserIdOfSession);
      }
      BaseVariableState clientUserIdHistory = (BaseVariableState) this.m_variable.ClientUserIdHistory;
      if (clientUserIdHistory != null)
      {
        clientUserIdHistory.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientUserIdHistory);
        clientUserIdHistory.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientUserIdHistory);
        updateList.Add((BaseInstanceState) clientUserIdHistory);
      }
      BaseVariableState authenticationMechanism = (BaseVariableState) this.m_variable.AuthenticationMechanism;
      if (authenticationMechanism != null)
      {
        authenticationMechanism.OnReadValue = new NodeValueEventHandler(this.OnRead_AuthenticationMechanism);
        authenticationMechanism.OnWriteValue = new NodeValueEventHandler(this.OnWrite_AuthenticationMechanism);
        updateList.Add((BaseInstanceState) authenticationMechanism);
      }
      BaseVariableState encoding = (BaseVariableState) this.m_variable.Encoding;
      if (encoding != null)
      {
        encoding.OnReadValue = new NodeValueEventHandler(this.OnRead_Encoding);
        encoding.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Encoding);
        updateList.Add((BaseInstanceState) encoding);
      }
      BaseVariableState transportProtocol = (BaseVariableState) this.m_variable.TransportProtocol;
      if (transportProtocol != null)
      {
        transportProtocol.OnReadValue = new NodeValueEventHandler(this.OnRead_TransportProtocol);
        transportProtocol.OnWriteValue = new NodeValueEventHandler(this.OnWrite_TransportProtocol);
        updateList.Add((BaseInstanceState) transportProtocol);
      }
      BaseVariableState securityMode = (BaseVariableState) this.m_variable.SecurityMode;
      if (securityMode != null)
      {
        securityMode.OnReadValue = new NodeValueEventHandler(this.OnRead_SecurityMode);
        securityMode.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SecurityMode);
        updateList.Add((BaseInstanceState) securityMode);
      }
      BaseVariableState securityPolicyUri = (BaseVariableState) this.m_variable.SecurityPolicyUri;
      if (securityPolicyUri != null)
      {
        securityPolicyUri.OnReadValue = new NodeValueEventHandler(this.OnRead_SecurityPolicyUri);
        securityPolicyUri.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SecurityPolicyUri);
        updateList.Add((BaseInstanceState) securityPolicyUri);
      }
      BaseVariableState clientCertificate = (BaseVariableState) this.m_variable.ClientCertificate;
      if (clientCertificate != null)
      {
        clientCertificate.OnReadValue = new NodeValueEventHandler(this.OnRead_ClientCertificate);
        clientCertificate.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ClientCertificate);
        updateList.Add((BaseInstanceState) clientCertificate);
      }
      this.SetUpdateList((IList<BaseInstanceState>) updateList);
    }
  }

  protected ServiceResult OnReadValue(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      if (this.m_value != null)
        value = (object) this.m_value;
      return this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
    }
  }

  private ServiceResult OnWriteValue(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      SessionSecurityDiagnosticsDataType newValue = !(value is ExtensionObject extensionObject) ? (SessionSecurityDiagnosticsDataType) value : (SessionSecurityDiagnosticsDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (SessionSecurityDiagnosticsDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref SessionSecurityDiagnosticsDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.SessionId, (object) newValue.SessionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ClientUserIdOfSession, (object) newValue.ClientUserIdOfSession))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientUserIdOfSession, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ClientUserIdHistory, (object) newValue.ClientUserIdHistory))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientUserIdHistory, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.AuthenticationMechanism, (object) newValue.AuthenticationMechanism))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AuthenticationMechanism, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.Encoding, (object) newValue.Encoding))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Encoding, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.TransportProtocol, (object) newValue.TransportProtocol))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransportProtocol, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SecurityMode, (object) newValue.SecurityMode))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityMode, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SecurityPolicyUri, (object) newValue.SecurityPolicyUri))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityPolicyUri, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.ClientCertificate, (object) newValue.ClientCertificate))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientCertificate, ref statusCode, ref timestamp);
  }

  private void UpdateParent(
    ISystemContext context,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    this.Timestamp = timestamp;
    this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
    this.m_variable.ClearChangeMasks(context, false);
  }

  private void UpdateChildVariableStatus(
    BaseVariableState child,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (child == null)
      return;
    child.StatusCode = statusCode;
    if (timestamp == DateTime.MinValue)
      timestamp = DateTime.UtcNow;
    child.Timestamp = timestamp;
  }

  private ServiceResult OnRead_SessionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<NodeId> sessionId = this.m_variable?.SessionId;
      if (sessionId != null && StatusCode.IsBad(sessionId.StatusCode))
      {
        value = (object) null;
        statusCode = sessionId.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SessionId;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (sessionId != null && ServiceResult.IsNotBad(status))
      {
        timestamp = sessionId.Timestamp;
        if (statusCode != sessionId.StatusCode)
        {
          statusCode = sessionId.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SessionId(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionId, ref statusCode, ref timestamp);
      this.m_value.SessionId = (NodeId) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientUserIdOfSession(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string> clientUserIdOfSession = this.m_variable?.ClientUserIdOfSession;
      if (clientUserIdOfSession != null && StatusCode.IsBad(clientUserIdOfSession.StatusCode))
      {
        value = (object) null;
        statusCode = clientUserIdOfSession.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientUserIdOfSession;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientUserIdOfSession != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientUserIdOfSession.Timestamp;
        if (statusCode != clientUserIdOfSession.StatusCode)
        {
          statusCode = clientUserIdOfSession.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientUserIdOfSession(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientUserIdOfSession, ref statusCode, ref timestamp);
      this.m_value.ClientUserIdOfSession = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientUserIdHistory(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string[]> clientUserIdHistory = this.m_variable?.ClientUserIdHistory;
      if (clientUserIdHistory != null && StatusCode.IsBad(clientUserIdHistory.StatusCode))
      {
        value = (object) null;
        statusCode = clientUserIdHistory.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientUserIdHistory;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientUserIdHistory != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientUserIdHistory.Timestamp;
        if (statusCode != clientUserIdHistory.StatusCode)
        {
          statusCode = clientUserIdHistory.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientUserIdHistory(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientUserIdHistory, ref statusCode, ref timestamp);
      this.m_value.ClientUserIdHistory = (StringCollection) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_AuthenticationMechanism(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string> authenticationMechanism = this.m_variable?.AuthenticationMechanism;
      if (authenticationMechanism != null && StatusCode.IsBad(authenticationMechanism.StatusCode))
      {
        value = (object) null;
        statusCode = authenticationMechanism.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.AuthenticationMechanism;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (authenticationMechanism != null && ServiceResult.IsNotBad(status))
      {
        timestamp = authenticationMechanism.Timestamp;
        if (statusCode != authenticationMechanism.StatusCode)
        {
          statusCode = authenticationMechanism.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_AuthenticationMechanism(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.AuthenticationMechanism, ref statusCode, ref timestamp);
      this.m_value.AuthenticationMechanism = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Encoding(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string> encoding = this.m_variable?.Encoding;
      if (encoding != null && StatusCode.IsBad(encoding.StatusCode))
      {
        value = (object) null;
        statusCode = encoding.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Encoding;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (encoding != null && ServiceResult.IsNotBad(status))
      {
        timestamp = encoding.Timestamp;
        if (statusCode != encoding.StatusCode)
        {
          statusCode = encoding.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Encoding(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Encoding, ref statusCode, ref timestamp);
      this.m_value.Encoding = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_TransportProtocol(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string> transportProtocol = this.m_variable?.TransportProtocol;
      if (transportProtocol != null && StatusCode.IsBad(transportProtocol.StatusCode))
      {
        value = (object) null;
        statusCode = transportProtocol.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.TransportProtocol;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (transportProtocol != null && ServiceResult.IsNotBad(status))
      {
        timestamp = transportProtocol.Timestamp;
        if (statusCode != transportProtocol.StatusCode)
        {
          statusCode = transportProtocol.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_TransportProtocol(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.TransportProtocol, ref statusCode, ref timestamp);
      this.m_value.TransportProtocol = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SecurityMode(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<MessageSecurityMode> securityMode = this.m_variable?.SecurityMode;
      if (securityMode != null && StatusCode.IsBad(securityMode.StatusCode))
      {
        value = (object) null;
        statusCode = securityMode.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SecurityMode;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (securityMode != null && ServiceResult.IsNotBad(status))
      {
        timestamp = securityMode.Timestamp;
        if (statusCode != securityMode.StatusCode)
        {
          statusCode = securityMode.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SecurityMode(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityMode, ref statusCode, ref timestamp);
      this.m_value.SecurityMode = (MessageSecurityMode) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SecurityPolicyUri(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<string> securityPolicyUri = this.m_variable?.SecurityPolicyUri;
      if (securityPolicyUri != null && StatusCode.IsBad(securityPolicyUri.StatusCode))
      {
        value = (object) null;
        statusCode = securityPolicyUri.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SecurityPolicyUri;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (securityPolicyUri != null && ServiceResult.IsNotBad(status))
      {
        timestamp = securityPolicyUri.Timestamp;
        if (statusCode != securityPolicyUri.StatusCode)
        {
          statusCode = securityPolicyUri.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SecurityPolicyUri(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityPolicyUri, ref statusCode, ref timestamp);
      this.m_value.SecurityPolicyUri = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ClientCertificate(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.DoBeforeReadProcessing(context, node);
      BaseDataVariableState<byte[]> clientCertificate = this.m_variable?.ClientCertificate;
      if (clientCertificate != null && StatusCode.IsBad(clientCertificate.StatusCode))
      {
        value = (object) null;
        statusCode = clientCertificate.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ClientCertificate;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (clientCertificate != null && ServiceResult.IsNotBad(status))
      {
        timestamp = clientCertificate.Timestamp;
        if (statusCode != clientCertificate.StatusCode)
        {
          statusCode = clientCertificate.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ClientCertificate(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.Lock)
    {
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ClientCertificate, ref statusCode, ref timestamp);
      this.m_value.ClientCertificate = (byte[]) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
