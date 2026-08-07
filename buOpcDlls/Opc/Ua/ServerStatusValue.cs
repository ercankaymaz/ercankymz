// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerStatusValue
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
public class ServerStatusValue : BaseVariableValue
{
  private ServerStatusDataType m_value;
  private ServerStatusState m_variable;

  public ServerStatusValue(ServerStatusState variable, ServerStatusDataType value, object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ServerStatusDataType();
    this.Initialize(variable);
  }

  public ServerStatusState Variable => this.m_variable;

  public ServerStatusDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ServerStatusState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState startTime = (BaseVariableState) this.m_variable.StartTime;
      if (startTime != null)
      {
        startTime.OnReadValue = new NodeValueEventHandler(this.OnRead_StartTime);
        startTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_StartTime);
        updateList.Add((BaseInstanceState) startTime);
      }
      BaseVariableState currentTime = (BaseVariableState) this.m_variable.CurrentTime;
      if (currentTime != null)
      {
        currentTime.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentTime);
        currentTime.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentTime);
        updateList.Add((BaseInstanceState) currentTime);
      }
      BaseVariableState state = (BaseVariableState) this.m_variable.State;
      if (state != null)
      {
        state.OnReadValue = new NodeValueEventHandler(this.OnRead_State);
        state.OnWriteValue = new NodeValueEventHandler(this.OnWrite_State);
        updateList.Add((BaseInstanceState) state);
      }
      BaseVariableState buildInfo = (BaseVariableState) this.m_variable.BuildInfo;
      if (buildInfo != null)
      {
        buildInfo.OnReadValue = new NodeValueEventHandler(this.OnRead_BuildInfo);
        buildInfo.OnWriteValue = new NodeValueEventHandler(this.OnWrite_BuildInfo);
        updateList.Add((BaseInstanceState) buildInfo);
      }
      BaseVariableState secondsTillShutdown = (BaseVariableState) this.m_variable.SecondsTillShutdown;
      if (secondsTillShutdown != null)
      {
        secondsTillShutdown.OnReadValue = new NodeValueEventHandler(this.OnRead_SecondsTillShutdown);
        secondsTillShutdown.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SecondsTillShutdown);
        updateList.Add((BaseInstanceState) secondsTillShutdown);
      }
      BaseVariableState shutdownReason = (BaseVariableState) this.m_variable.ShutdownReason;
      if (shutdownReason != null)
      {
        shutdownReason.OnReadValue = new NodeValueEventHandler(this.OnRead_ShutdownReason);
        shutdownReason.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ShutdownReason);
        updateList.Add((BaseInstanceState) shutdownReason);
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
      ServerStatusDataType newValue = !(value is ExtensionObject extensionObject) ? (ServerStatusDataType) value : (ServerStatusDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ServerStatusDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ServerStatusDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual(this.m_value.StartTime, newValue.StartTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.StartTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual(this.m_value.CurrentTime, newValue.CurrentTime))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentTime, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.State, (object) newValue.State))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.State, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.BuildInfo, (object) newValue.BuildInfo))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildInfo, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SecondsTillShutdown, (object) newValue.SecondsTillShutdown))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecondsTillShutdown, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.ShutdownReason, (object) newValue.ShutdownReason))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ShutdownReason, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_StartTime(
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
      BaseDataVariableState<DateTime> startTime = this.m_variable?.StartTime;
      if (startTime != null && StatusCode.IsBad(startTime.StatusCode))
      {
        value = (object) null;
        statusCode = startTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.StartTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (startTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = startTime.Timestamp;
        if (statusCode != startTime.StatusCode)
        {
          statusCode = startTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_StartTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.StartTime, ref statusCode, ref timestamp);
      this.m_value.StartTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentTime(
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
      BaseDataVariableState<DateTime> currentTime = this.m_variable?.CurrentTime;
      if (currentTime != null && StatusCode.IsBad(currentTime.StatusCode))
      {
        value = (object) null;
        statusCode = currentTime.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentTime;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (currentTime != null && ServiceResult.IsNotBad(status))
      {
        timestamp = currentTime.Timestamp;
        if (statusCode != currentTime.StatusCode)
        {
          statusCode = currentTime.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentTime(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentTime, ref statusCode, ref timestamp);
      this.m_value.CurrentTime = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_State(
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
      BaseDataVariableState<ServerState> state = this.m_variable?.State;
      if (state != null && StatusCode.IsBad(state.StatusCode))
      {
        value = (object) null;
        statusCode = state.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.State;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (state != null && ServiceResult.IsNotBad(status))
      {
        timestamp = state.Timestamp;
        if (statusCode != state.StatusCode)
        {
          statusCode = state.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_State(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.State, ref statusCode, ref timestamp);
      this.m_value.State = (ServerState) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_BuildInfo(
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
      BuildInfoVariableState buildInfo = this.m_variable?.BuildInfo;
      if (buildInfo != null && StatusCode.IsBad(buildInfo.StatusCode))
      {
        value = (object) null;
        statusCode = buildInfo.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.BuildInfo;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (buildInfo != null && ServiceResult.IsNotBad(status))
      {
        timestamp = buildInfo.Timestamp;
        if (statusCode != buildInfo.StatusCode)
        {
          statusCode = buildInfo.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_BuildInfo(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildInfo, ref statusCode, ref timestamp);
      this.m_value.BuildInfo = (BuildInfo) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SecondsTillShutdown(
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
      BaseDataVariableState<uint> secondsTillShutdown = this.m_variable?.SecondsTillShutdown;
      if (secondsTillShutdown != null && StatusCode.IsBad(secondsTillShutdown.StatusCode))
      {
        value = (object) null;
        statusCode = secondsTillShutdown.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SecondsTillShutdown;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (secondsTillShutdown != null && ServiceResult.IsNotBad(status))
      {
        timestamp = secondsTillShutdown.Timestamp;
        if (statusCode != secondsTillShutdown.StatusCode)
        {
          statusCode = secondsTillShutdown.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SecondsTillShutdown(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecondsTillShutdown, ref statusCode, ref timestamp);
      this.m_value.SecondsTillShutdown = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ShutdownReason(
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
      BaseDataVariableState<LocalizedText> shutdownReason = this.m_variable?.ShutdownReason;
      if (shutdownReason != null && StatusCode.IsBad(shutdownReason.StatusCode))
      {
        value = (object) null;
        statusCode = shutdownReason.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ShutdownReason;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (shutdownReason != null && ServiceResult.IsNotBad(status))
      {
        timestamp = shutdownReason.Timestamp;
        if (statusCode != shutdownReason.StatusCode)
        {
          statusCode = shutdownReason.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ShutdownReason(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ShutdownReason, ref statusCode, ref timestamp);
      this.m_value.ShutdownReason = (LocalizedText) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
