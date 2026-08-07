// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RationalNumberValue
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
public class RationalNumberValue : BaseVariableValue
{
  private RationalNumber m_value;
  private RationalNumberState m_variable;

  public RationalNumberValue(RationalNumberState variable, RationalNumber value, object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new RationalNumber();
    this.Initialize(variable);
  }

  public RationalNumberState Variable => this.m_variable;

  public RationalNumber Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(RationalNumberState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState numerator = (BaseVariableState) this.m_variable.Numerator;
      if (numerator != null)
      {
        numerator.OnReadValue = new NodeValueEventHandler(this.OnRead_Numerator);
        numerator.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Numerator);
        updateList.Add((BaseInstanceState) numerator);
      }
      BaseVariableState denominator = (BaseVariableState) this.m_variable.Denominator;
      if (denominator != null)
      {
        denominator.OnReadValue = new NodeValueEventHandler(this.OnRead_Denominator);
        denominator.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Denominator);
        updateList.Add((BaseInstanceState) denominator);
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
      RationalNumber newValue = !(value is ExtensionObject extensionObject) ? (RationalNumber) value : (RationalNumber) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (RationalNumber) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref RationalNumber newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.Numerator, (object) newValue.Numerator))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Numerator, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.Denominator, (object) newValue.Denominator))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Denominator, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_Numerator(
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
      BaseDataVariableState<int> numerator = this.m_variable?.Numerator;
      if (numerator != null && StatusCode.IsBad(numerator.StatusCode))
      {
        value = (object) null;
        statusCode = numerator.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Numerator;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (numerator != null && ServiceResult.IsNotBad(status))
      {
        timestamp = numerator.Timestamp;
        if (statusCode != numerator.StatusCode)
        {
          statusCode = numerator.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Numerator(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Numerator, ref statusCode, ref timestamp);
      this.m_value.Numerator = (int) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Denominator(
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
      BaseDataVariableState<uint> denominator = this.m_variable?.Denominator;
      if (denominator != null && StatusCode.IsBad(denominator.StatusCode))
      {
        value = (object) null;
        statusCode = denominator.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Denominator;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (denominator != null && ServiceResult.IsNotBad(status))
      {
        timestamp = denominator.Timestamp;
        if (statusCode != denominator.StatusCode)
        {
          statusCode = denominator.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Denominator(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Denominator, ref statusCode, ref timestamp);
      this.m_value.Denominator = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
