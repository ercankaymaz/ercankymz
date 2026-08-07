// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SamplingIntervalDiagnosticsValue
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
public class SamplingIntervalDiagnosticsValue : BaseVariableValue
{
  private SamplingIntervalDiagnosticsDataType m_value;
  private SamplingIntervalDiagnosticsState m_variable;

  public SamplingIntervalDiagnosticsValue(
    SamplingIntervalDiagnosticsState variable,
    SamplingIntervalDiagnosticsDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new SamplingIntervalDiagnosticsDataType();
    this.Initialize(variable);
  }

  public SamplingIntervalDiagnosticsState Variable => this.m_variable;

  public SamplingIntervalDiagnosticsDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(SamplingIntervalDiagnosticsState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState samplingInterval = (BaseVariableState) this.m_variable.SamplingInterval;
      if (samplingInterval != null)
      {
        samplingInterval.OnReadValue = new NodeValueEventHandler(this.OnRead_SamplingInterval);
        samplingInterval.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SamplingInterval);
        updateList.Add((BaseInstanceState) samplingInterval);
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
      SamplingIntervalDiagnosticsDataType newValue = !(value is ExtensionObject extensionObject) ? (SamplingIntervalDiagnosticsDataType) value : (SamplingIntervalDiagnosticsDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (SamplingIntervalDiagnosticsDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref SamplingIntervalDiagnosticsDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (Utils.IsEqual((object) this.m_value.SamplingInterval, (object) newValue.SamplingInterval))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SamplingInterval, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_SamplingInterval(
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
      BaseDataVariableState<double> samplingInterval = this.m_variable?.SamplingInterval;
      if (samplingInterval != null && StatusCode.IsBad(samplingInterval.StatusCode))
      {
        value = (object) null;
        statusCode = samplingInterval.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SamplingInterval;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (samplingInterval != null && ServiceResult.IsNotBad(status))
      {
        timestamp = samplingInterval.Timestamp;
        if (statusCode != samplingInterval.StatusCode)
        {
          statusCode = samplingInterval.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SamplingInterval(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SamplingInterval, ref statusCode, ref timestamp);
      this.m_value.SamplingInterval = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
