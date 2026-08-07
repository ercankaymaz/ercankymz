// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BuildInfoVariableValue
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
public class BuildInfoVariableValue : BaseVariableValue
{
  private BuildInfo m_value;
  private BuildInfoVariableState m_variable;

  public BuildInfoVariableValue(BuildInfoVariableState variable, BuildInfo value, object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new BuildInfo();
    this.Initialize(variable);
  }

  public BuildInfoVariableState Variable => this.m_variable;

  public BuildInfo Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(BuildInfoVariableState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState productUri = (BaseVariableState) this.m_variable.ProductUri;
      if (productUri != null)
      {
        productUri.OnReadValue = new NodeValueEventHandler(this.OnRead_ProductUri);
        productUri.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ProductUri);
        updateList.Add((BaseInstanceState) productUri);
      }
      BaseVariableState manufacturerName = (BaseVariableState) this.m_variable.ManufacturerName;
      if (manufacturerName != null)
      {
        manufacturerName.OnReadValue = new NodeValueEventHandler(this.OnRead_ManufacturerName);
        manufacturerName.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ManufacturerName);
        updateList.Add((BaseInstanceState) manufacturerName);
      }
      BaseVariableState productName = (BaseVariableState) this.m_variable.ProductName;
      if (productName != null)
      {
        productName.OnReadValue = new NodeValueEventHandler(this.OnRead_ProductName);
        productName.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ProductName);
        updateList.Add((BaseInstanceState) productName);
      }
      BaseVariableState softwareVersion = (BaseVariableState) this.m_variable.SoftwareVersion;
      if (softwareVersion != null)
      {
        softwareVersion.OnReadValue = new NodeValueEventHandler(this.OnRead_SoftwareVersion);
        softwareVersion.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SoftwareVersion);
        updateList.Add((BaseInstanceState) softwareVersion);
      }
      BaseVariableState buildNumber = (BaseVariableState) this.m_variable.BuildNumber;
      if (buildNumber != null)
      {
        buildNumber.OnReadValue = new NodeValueEventHandler(this.OnRead_BuildNumber);
        buildNumber.OnWriteValue = new NodeValueEventHandler(this.OnWrite_BuildNumber);
        updateList.Add((BaseInstanceState) buildNumber);
      }
      BaseVariableState buildDate = (BaseVariableState) this.m_variable.BuildDate;
      if (buildDate != null)
      {
        buildDate.OnReadValue = new NodeValueEventHandler(this.OnRead_BuildDate);
        buildDate.OnWriteValue = new NodeValueEventHandler(this.OnWrite_BuildDate);
        updateList.Add((BaseInstanceState) buildDate);
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
      BuildInfo newValue = !(value is ExtensionObject extensionObject) ? (BuildInfo) value : (BuildInfo) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (BuildInfo) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref BuildInfo newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.ProductUri, (object) newValue.ProductUri))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ProductUri, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ManufacturerName, (object) newValue.ManufacturerName))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ManufacturerName, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.ProductName, (object) newValue.ProductName))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ProductName, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SoftwareVersion, (object) newValue.SoftwareVersion))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SoftwareVersion, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.BuildNumber, (object) newValue.BuildNumber))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildNumber, ref statusCode, ref timestamp);
    if (Utils.IsEqual(this.m_value.BuildDate, newValue.BuildDate))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildDate, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_ProductUri(
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
      BaseDataVariableState<string> productUri = this.m_variable?.ProductUri;
      if (productUri != null && StatusCode.IsBad(productUri.StatusCode))
      {
        value = (object) null;
        statusCode = productUri.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ProductUri;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (productUri != null && ServiceResult.IsNotBad(status))
      {
        timestamp = productUri.Timestamp;
        if (statusCode != productUri.StatusCode)
        {
          statusCode = productUri.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ProductUri(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ProductUri, ref statusCode, ref timestamp);
      this.m_value.ProductUri = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ManufacturerName(
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
      BaseDataVariableState<string> manufacturerName = this.m_variable?.ManufacturerName;
      if (manufacturerName != null && StatusCode.IsBad(manufacturerName.StatusCode))
      {
        value = (object) null;
        statusCode = manufacturerName.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ManufacturerName;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (manufacturerName != null && ServiceResult.IsNotBad(status))
      {
        timestamp = manufacturerName.Timestamp;
        if (statusCode != manufacturerName.StatusCode)
        {
          statusCode = manufacturerName.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ManufacturerName(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ManufacturerName, ref statusCode, ref timestamp);
      this.m_value.ManufacturerName = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_ProductName(
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
      BaseDataVariableState<string> productName = this.m_variable?.ProductName;
      if (productName != null && StatusCode.IsBad(productName.StatusCode))
      {
        value = (object) null;
        statusCode = productName.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ProductName;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (productName != null && ServiceResult.IsNotBad(status))
      {
        timestamp = productName.Timestamp;
        if (statusCode != productName.StatusCode)
        {
          statusCode = productName.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ProductName(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ProductName, ref statusCode, ref timestamp);
      this.m_value.ProductName = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SoftwareVersion(
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
      BaseDataVariableState<string> softwareVersion = this.m_variable?.SoftwareVersion;
      if (softwareVersion != null && StatusCode.IsBad(softwareVersion.StatusCode))
      {
        value = (object) null;
        statusCode = softwareVersion.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SoftwareVersion;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (softwareVersion != null && ServiceResult.IsNotBad(status))
      {
        timestamp = softwareVersion.Timestamp;
        if (statusCode != softwareVersion.StatusCode)
        {
          statusCode = softwareVersion.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SoftwareVersion(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SoftwareVersion, ref statusCode, ref timestamp);
      this.m_value.SoftwareVersion = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_BuildNumber(
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
      BaseDataVariableState<string> buildNumber = this.m_variable?.BuildNumber;
      if (buildNumber != null && StatusCode.IsBad(buildNumber.StatusCode))
      {
        value = (object) null;
        statusCode = buildNumber.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.BuildNumber;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (buildNumber != null && ServiceResult.IsNotBad(status))
      {
        timestamp = buildNumber.Timestamp;
        if (statusCode != buildNumber.StatusCode)
        {
          statusCode = buildNumber.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_BuildNumber(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildNumber, ref statusCode, ref timestamp);
      this.m_value.BuildNumber = (string) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_BuildDate(
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
      BaseDataVariableState<DateTime> buildDate = this.m_variable?.BuildDate;
      if (buildDate != null && StatusCode.IsBad(buildDate.StatusCode))
      {
        value = (object) null;
        statusCode = buildDate.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.BuildDate;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (buildDate != null && ServiceResult.IsNotBad(status))
      {
        timestamp = buildDate.Timestamp;
        if (statusCode != buildDate.StatusCode)
        {
          statusCode = buildDate.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_BuildDate(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.BuildDate, ref statusCode, ref timestamp);
      this.m_value.BuildDate = (DateTime) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
