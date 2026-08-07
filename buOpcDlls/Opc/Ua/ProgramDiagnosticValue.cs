// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramDiagnosticValue
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
public class ProgramDiagnosticValue : BaseVariableValue
{
  private ProgramDiagnosticDataType m_value;
  private ProgramDiagnosticState m_variable;

  public ProgramDiagnosticValue(
    ProgramDiagnosticState variable,
    ProgramDiagnosticDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ProgramDiagnosticDataType();
    this.Initialize(variable);
  }

  public ProgramDiagnosticState Variable => this.m_variable;

  public ProgramDiagnosticDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ProgramDiagnosticState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState createSessionId = (BaseVariableState) this.m_variable.CreateSessionId;
      if (createSessionId != null)
      {
        createSessionId.OnReadValue = new NodeValueEventHandler(this.OnRead_CreateSessionId);
        createSessionId.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CreateSessionId);
        updateList.Add((BaseInstanceState) createSessionId);
      }
      BaseVariableState createClientName = (BaseVariableState) this.m_variable.CreateClientName;
      if (createClientName != null)
      {
        createClientName.OnReadValue = new NodeValueEventHandler(this.OnRead_CreateClientName);
        createClientName.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CreateClientName);
        updateList.Add((BaseInstanceState) createClientName);
      }
      BaseVariableState invocationCreationTime = (BaseVariableState) this.m_variable.InvocationCreationTime;
      if (invocationCreationTime != null)
      {
        invocationCreationTime.OnReadValue = new NodeValueEventHandler(this.OnRead_InvocationCreationTime);
        invocationCreationTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_InvocationCreationTime);
        updateList.Add((BaseInstanceState) invocationCreationTime);
      }
      BaseVariableState lastTransitionTime = (BaseVariableState) this.m_variable.LastTransitionTime;
      if (lastTransitionTime != null)
      {
        lastTransitionTime.OnReadValue = new NodeValueEventHandler(this.OnRead_LastTransitionTime);
        lastTransitionTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastTransitionTime);
        updateList.Add((BaseInstanceState) lastTransitionTime);
      }
      BaseVariableState lastMethodCall = (BaseVariableState) this.m_variable.LastMethodCall;
      if (lastMethodCall != null)
      {
        lastMethodCall.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodCall);
        lastMethodCall.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodCall);
        updateList.Add((BaseInstanceState) lastMethodCall);
      }
      BaseVariableState lastMethodSessionId = (BaseVariableState) this.m_variable.LastMethodSessionId;
      if (lastMethodSessionId != null)
      {
        lastMethodSessionId.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodSessionId);
        lastMethodSessionId.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodSessionId);
        updateList.Add((BaseInstanceState) lastMethodSessionId);
      }
      BaseVariableState methodInputArguments = (BaseVariableState) this.m_variable.LastMethodInputArguments;
      if (methodInputArguments != null)
      {
        methodInputArguments.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodInputArguments);
        methodInputArguments.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodInputArguments);
        updateList.Add((BaseInstanceState) methodInputArguments);
      }
      BaseVariableState methodOutputArguments = (BaseVariableState) this.m_variable.LastMethodOutputArguments;
      if (methodOutputArguments != null)
      {
        methodOutputArguments.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodOutputArguments);
        methodOutputArguments.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodOutputArguments);
        updateList.Add((BaseInstanceState) methodOutputArguments);
      }
      BaseVariableState lastMethodCallTime = (BaseVariableState) this.m_variable.LastMethodCallTime;
      if (lastMethodCallTime != null)
      {
        lastMethodCallTime.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodCallTime);
        lastMethodCallTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodCallTime);
        updateList.Add((BaseInstanceState) lastMethodCallTime);
      }
      BaseVariableState methodReturnStatus = (BaseVariableState) this.m_variable.LastMethodReturnStatus;
      if (methodReturnStatus != null)
      {
        methodReturnStatus.OnReadValue = new NodeValueEventHandler(this.OnRead_LastMethodReturnStatus);
        methodReturnStatus.OnWriteValue = new NodeValueEventHandler(this.OnWrite_LastMethodReturnStatus);
        updateList.Add((BaseInstanceState) methodReturnStatus);
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
      ProgramDiagnosticDataType newValue = !(value is ExtensionObject extensionObject) ? (ProgramDiagnosticDataType) value : (ProgramDiagnosticDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ProgramDiagnosticDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ProgramDiagnosticDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.CreateSessionId, (object) newValue.CreateSessionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateSessionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CreateClientName, (object) newValue.CreateClientName))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateClientName, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.InvocationCreationTime, newValue.InvocationCreationTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.InvocationCreationTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.LastTransitionTime, newValue.LastTransitionTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastTransitionTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LastMethodCall, (object) newValue.LastMethodCall))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodCall, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LastMethodSessionId, (object) newValue.LastMethodSessionId))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodSessionId, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LastMethodInputArguments, (object) newValue.LastMethodInputArguments))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodInputArguments, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.LastMethodOutputArguments, (object) newValue.LastMethodOutputArguments))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodOutputArguments, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.LastMethodCallTime, newValue.LastMethodCallTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodCallTime, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.LastMethodReturnStatus, (object) newValue.LastMethodReturnStatus))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodReturnStatus, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_CreateSessionId(
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
      PropertyState<NodeId> createSessionId = this.m_variable?.CreateSessionId;
      if (createSessionId != null && StatusCode.IsBad(createSessionId.StatusCode))
      {
        value = (object) null;
        statusCode = createSessionId.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CreateSessionId;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (createSessionId != null && ServiceResult.IsNotBad(status))
      {
        timestamp = createSessionId.Timestamp;
        if (statusCode != createSessionId.StatusCode)
        {
          statusCode = createSessionId.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CreateSessionId(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateSessionId, ref statusCode, ref timestamp);
      this.m_value.CreateSessionId = (NodeId) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CreateClientName(
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
      PropertyState<string> createClientName = this.m_variable?.CreateClientName;
      if (createClientName != null && StatusCode.IsBad(createClientName.StatusCode))
      {
        value = (object) null;
        statusCode = createClientName.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CreateClientName;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (createClientName != null && ServiceResult.IsNotBad(status))
      {
        timestamp = createClientName.Timestamp;
        if (statusCode != createClientName.StatusCode)
        {
          statusCode = createClientName.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CreateClientName(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CreateClientName, ref statusCode, ref timestamp);
      this.m_value.CreateClientName = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_InvocationCreationTime(
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
      PropertyState<DateTime> invocationCreationTime = this.m_variable?.InvocationCreationTime;
      if (invocationCreationTime != null && StatusCode.IsBad(invocationCreationTime.StatusCode))
      {
        value = (object) null;
        statusCode = invocationCreationTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.InvocationCreationTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (invocationCreationTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = invocationCreationTime.Timestamp;
        if (statusCode != invocationCreationTime.StatusCode)
        {
          statusCode = invocationCreationTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_InvocationCreationTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.InvocationCreationTime, ref statusCode, ref timestamp);
      this.m_value.InvocationCreationTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastTransitionTime(
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
      PropertyState<DateTime> lastTransitionTime = this.m_variable?.LastTransitionTime;
      if (lastTransitionTime != null && StatusCode.IsBad(lastTransitionTime.StatusCode))
      {
        value = (object) null;
        statusCode = lastTransitionTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastTransitionTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (lastTransitionTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = lastTransitionTime.Timestamp;
        if (statusCode != lastTransitionTime.StatusCode)
        {
          statusCode = lastTransitionTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastTransitionTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastTransitionTime, ref statusCode, ref timestamp);
      this.m_value.LastTransitionTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodCall(
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
      PropertyState<string> lastMethodCall = this.m_variable?.LastMethodCall;
      if (lastMethodCall != null && StatusCode.IsBad(lastMethodCall.StatusCode))
      {
        value = (object) null;
        statusCode = lastMethodCall.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodCall;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (lastMethodCall != null && ServiceResult.IsNotBad(status))
      {
        timestamp = lastMethodCall.Timestamp;
        if (statusCode != lastMethodCall.StatusCode)
        {
          statusCode = lastMethodCall.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodCall(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodCall, ref statusCode, ref timestamp);
      this.m_value.LastMethodCall = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodSessionId(
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
      PropertyState<NodeId> lastMethodSessionId = this.m_variable?.LastMethodSessionId;
      if (lastMethodSessionId != null && StatusCode.IsBad(lastMethodSessionId.StatusCode))
      {
        value = (object) null;
        statusCode = lastMethodSessionId.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodSessionId;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (lastMethodSessionId != null && ServiceResult.IsNotBad(status))
      {
        timestamp = lastMethodSessionId.Timestamp;
        if (statusCode != lastMethodSessionId.StatusCode)
        {
          statusCode = lastMethodSessionId.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodSessionId(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodSessionId, ref statusCode, ref timestamp);
      this.m_value.LastMethodSessionId = (NodeId) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodInputArguments(
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
      PropertyState<object[]> methodInputArguments = this.m_variable?.LastMethodInputArguments;
      if (methodInputArguments != null && StatusCode.IsBad(methodInputArguments.StatusCode))
      {
        value = (object) null;
        statusCode = methodInputArguments.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodInputArguments;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (methodInputArguments != null && ServiceResult.IsNotBad(status))
      {
        timestamp = methodInputArguments.Timestamp;
        if (statusCode != methodInputArguments.StatusCode)
        {
          statusCode = methodInputArguments.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodInputArguments(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodInputArguments, ref statusCode, ref timestamp);
      this.m_value.LastMethodInputArguments = (ArgumentCollection) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodOutputArguments(
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
      PropertyState<object[]> methodOutputArguments = this.m_variable?.LastMethodOutputArguments;
      if (methodOutputArguments != null && StatusCode.IsBad(methodOutputArguments.StatusCode))
      {
        value = (object) null;
        statusCode = methodOutputArguments.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodOutputArguments;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (methodOutputArguments != null && ServiceResult.IsNotBad(status))
      {
        timestamp = methodOutputArguments.Timestamp;
        if (statusCode != methodOutputArguments.StatusCode)
        {
          statusCode = methodOutputArguments.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodOutputArguments(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodOutputArguments, ref statusCode, ref timestamp);
      this.m_value.LastMethodOutputArguments = (ArgumentCollection) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodCallTime(
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
      PropertyState<DateTime> lastMethodCallTime = this.m_variable?.LastMethodCallTime;
      if (lastMethodCallTime != null && StatusCode.IsBad(lastMethodCallTime.StatusCode))
      {
        value = (object) null;
        statusCode = lastMethodCallTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodCallTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (lastMethodCallTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = lastMethodCallTime.Timestamp;
        if (statusCode != lastMethodCallTime.StatusCode)
        {
          statusCode = lastMethodCallTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodCallTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodCallTime, ref statusCode, ref timestamp);
      this.m_value.LastMethodCallTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_LastMethodReturnStatus(
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
      PropertyState<StatusResult> methodReturnStatus = this.m_variable?.LastMethodReturnStatus;
      if (methodReturnStatus != null && StatusCode.IsBad(methodReturnStatus.StatusCode))
      {
        value = (object) null;
        statusCode = methodReturnStatus.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.LastMethodReturnStatus;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (methodReturnStatus != null && ServiceResult.IsNotBad(status))
      {
        timestamp = methodReturnStatus.Timestamp;
        if (statusCode != methodReturnStatus.StatusCode)
        {
          statusCode = methodReturnStatus.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_LastMethodReturnStatus(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.LastMethodReturnStatus, ref statusCode, ref timestamp);
      this.m_value.LastMethodReturnStatus = (StatusResult) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
