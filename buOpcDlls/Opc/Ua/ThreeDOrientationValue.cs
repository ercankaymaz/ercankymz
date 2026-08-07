// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDOrientationValue
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
public class ThreeDOrientationValue : BaseVariableValue
{
  private ThreeDOrientation m_value;
  private ThreeDOrientationState m_variable;

  public ThreeDOrientationValue(
    ThreeDOrientationState variable,
    ThreeDOrientation value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ThreeDOrientation();
    this.Initialize(variable);
  }

  public ThreeDOrientationState Variable => this.m_variable;

  public ThreeDOrientation Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ThreeDOrientationState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = (Orientation) this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState a = (BaseVariableState) this.m_variable.A;
      if (a != null)
      {
        a.OnReadValue = new NodeValueEventHandler(this.OnRead_A);
        a.OnWriteValue = new NodeValueEventHandler(this.OnWrite_A);
        updateList.Add((BaseInstanceState) a);
      }
      BaseVariableState b = (BaseVariableState) this.m_variable.B;
      if (b != null)
      {
        b.OnReadValue = new NodeValueEventHandler(this.OnRead_B);
        b.OnWriteValue = new NodeValueEventHandler(this.OnWrite_B);
        updateList.Add((BaseInstanceState) b);
      }
      BaseVariableState c = (BaseVariableState) this.m_variable.C;
      if (c != null)
      {
        c.OnReadValue = new NodeValueEventHandler(this.OnRead_C);
        c.OnWriteValue = new NodeValueEventHandler(this.OnWrite_C);
        updateList.Add((BaseInstanceState) c);
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
      ThreeDOrientation newValue = !(value is ExtensionObject extensionObject) ? (ThreeDOrientation) value : (ThreeDOrientation) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ThreeDOrientation) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ThreeDOrientation newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.A, (object) newValue.A))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.A, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.B, (object) newValue.B))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.B, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.C, (object) newValue.C))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.C, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_A(
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
      BaseDataVariableState<double> a = this.m_variable?.A;
      if (a != null && StatusCode.IsBad(a.StatusCode))
      {
        value = (object) null;
        statusCode = a.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.A;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (a != null && ServiceResult.IsNotBad(status))
      {
        timestamp = a.Timestamp;
        if (statusCode != a.StatusCode)
        {
          statusCode = a.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_A(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.A, ref statusCode, ref timestamp);
      this.m_value.A = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_B(
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
      BaseDataVariableState<double> b = this.m_variable?.B;
      if (b != null && StatusCode.IsBad(b.StatusCode))
      {
        value = (object) null;
        statusCode = b.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.B;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (b != null && ServiceResult.IsNotBad(status))
      {
        timestamp = b.Timestamp;
        if (statusCode != b.StatusCode)
        {
          statusCode = b.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_B(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.B, ref statusCode, ref timestamp);
      this.m_value.B = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_C(
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
      BaseDataVariableState<double> c = this.m_variable?.C;
      if (c != null && StatusCode.IsBad(c.StatusCode))
      {
        value = (object) null;
        statusCode = c.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.C;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (c != null && ServiceResult.IsNotBad(status))
      {
        timestamp = c.Timestamp;
        if (statusCode != c.StatusCode)
        {
          statusCode = c.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_C(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.C, ref statusCode, ref timestamp);
      this.m_value.C = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
