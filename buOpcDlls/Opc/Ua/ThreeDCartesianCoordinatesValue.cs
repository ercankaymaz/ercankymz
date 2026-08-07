// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDCartesianCoordinatesValue
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
public class ThreeDCartesianCoordinatesValue : BaseVariableValue
{
  private ThreeDCartesianCoordinates m_value;
  private ThreeDCartesianCoordinatesState m_variable;

  public ThreeDCartesianCoordinatesValue(
    ThreeDCartesianCoordinatesState variable,
    ThreeDCartesianCoordinates value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ThreeDCartesianCoordinates();
    this.Initialize(variable);
  }

  public ThreeDCartesianCoordinatesState Variable => this.m_variable;

  public ThreeDCartesianCoordinates Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ThreeDCartesianCoordinatesState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = (CartesianCoordinates) this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState x = (BaseVariableState) this.m_variable.X;
      if (x != null)
      {
        x.OnReadValue = new NodeValueEventHandler(this.OnRead_X);
        x.OnWriteValue = new NodeValueEventHandler(this.OnWrite_X);
        updateList.Add((BaseInstanceState) x);
      }
      BaseVariableState y = (BaseVariableState) this.m_variable.Y;
      if (y != null)
      {
        y.OnReadValue = new NodeValueEventHandler(this.OnRead_Y);
        y.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Y);
        updateList.Add((BaseInstanceState) y);
      }
      BaseVariableState z = (BaseVariableState) this.m_variable.Z;
      if (z != null)
      {
        z.OnReadValue = new NodeValueEventHandler(this.OnRead_Z);
        z.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Z);
        updateList.Add((BaseInstanceState) z);
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
      ThreeDCartesianCoordinates newValue = !(value is ExtensionObject extensionObject) ? (ThreeDCartesianCoordinates) value : (ThreeDCartesianCoordinates) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ThreeDCartesianCoordinates) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ThreeDCartesianCoordinates newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.X, (object) newValue.X))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.X, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.Y, (object) newValue.Y))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Y, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.Z, (object) newValue.Z))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Z, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_X(
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
      BaseDataVariableState<double> x = this.m_variable?.X;
      if (x != null && StatusCode.IsBad(x.StatusCode))
      {
        value = (object) null;
        statusCode = x.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.X;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (x != null && ServiceResult.IsNotBad(status))
      {
        timestamp = x.Timestamp;
        if (statusCode != x.StatusCode)
        {
          statusCode = x.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_X(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.X, ref statusCode, ref timestamp);
      this.m_value.X = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Y(
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
      BaseDataVariableState<double> y = this.m_variable?.Y;
      if (y != null && StatusCode.IsBad(y.StatusCode))
      {
        value = (object) null;
        statusCode = y.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Y;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (y != null && ServiceResult.IsNotBad(status))
      {
        timestamp = y.Timestamp;
        if (statusCode != y.StatusCode)
        {
          statusCode = y.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Y(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Y, ref statusCode, ref timestamp);
      this.m_value.Y = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Z(
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
      BaseDataVariableState<double> z = this.m_variable?.Z;
      if (z != null && StatusCode.IsBad(z.StatusCode))
      {
        value = (object) null;
        statusCode = z.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Z;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (z != null && ServiceResult.IsNotBad(status))
      {
        timestamp = z.Timestamp;
        if (statusCode != z.StatusCode)
        {
          statusCode = z.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Z(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Z, ref statusCode, ref timestamp);
      this.m_value.Z = (double) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
