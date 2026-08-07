// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDFrameValue
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
public class ThreeDFrameValue : BaseVariableValue
{
  private ThreeDFrame m_value;
  private ThreeDFrameState m_variable;

  public ThreeDFrameValue(ThreeDFrameState variable, ThreeDFrame value, object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ThreeDFrame();
    this.Initialize(variable);
  }

  public ThreeDFrameState Variable => this.m_variable;

  public ThreeDFrame Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ThreeDFrameState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = (Frame) this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState cartesianCoordinates = (BaseVariableState) this.m_variable.CartesianCoordinates;
      if (cartesianCoordinates != null)
      {
        cartesianCoordinates.OnReadValue = new NodeValueEventHandler(this.OnRead_CartesianCoordinates);
        cartesianCoordinates.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CartesianCoordinates);
        updateList.Add((BaseInstanceState) cartesianCoordinates);
      }
      BaseVariableState orientation = (BaseVariableState) this.m_variable.Orientation;
      if (orientation != null)
      {
        orientation.OnReadValue = new NodeValueEventHandler(this.OnRead_Orientation);
        orientation.OnWriteValue = new NodeValueEventHandler(this.OnWrite_Orientation);
        updateList.Add((BaseInstanceState) orientation);
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
      ThreeDFrame newValue = !(value is ExtensionObject extensionObject) ? (ThreeDFrame) value : (ThreeDFrame) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ThreeDFrame) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ThreeDFrame newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.CartesianCoordinates, (object) newValue.CartesianCoordinates))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CartesianCoordinates, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.Orientation, (object) newValue.Orientation))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Orientation, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_CartesianCoordinates(
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
      ThreeDCartesianCoordinatesState cartesianCoordinates = this.m_variable?.CartesianCoordinates;
      if (cartesianCoordinates != null && StatusCode.IsBad(cartesianCoordinates.StatusCode))
      {
        value = (object) null;
        statusCode = cartesianCoordinates.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CartesianCoordinates;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (cartesianCoordinates != null && ServiceResult.IsNotBad(status))
      {
        timestamp = cartesianCoordinates.Timestamp;
        if (statusCode != cartesianCoordinates.StatusCode)
        {
          statusCode = cartesianCoordinates.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CartesianCoordinates(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CartesianCoordinates, ref statusCode, ref timestamp);
      this.m_value.CartesianCoordinates = (ThreeDCartesianCoordinates) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_Orientation(
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
      ThreeDOrientationState orientation = this.m_variable?.Orientation;
      if (orientation != null && StatusCode.IsBad(orientation.StatusCode))
      {
        value = (object) null;
        statusCode = orientation.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.Orientation;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (orientation != null && ServiceResult.IsNotBad(status))
      {
        timestamp = orientation.Timestamp;
        if (statusCode != orientation.StatusCode)
        {
          statusCode = orientation.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_Orientation(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.Orientation, ref statusCode, ref timestamp);
      this.m_value.Orientation = (ThreeDOrientation) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
