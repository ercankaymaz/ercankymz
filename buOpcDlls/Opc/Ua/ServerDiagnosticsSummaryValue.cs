// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerDiagnosticsSummaryValue
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
public class ServerDiagnosticsSummaryValue : BaseVariableValue
{
  private ServerDiagnosticsSummaryDataType m_value;
  private ServerDiagnosticsSummaryState m_variable;

  public ServerDiagnosticsSummaryValue(
    ServerDiagnosticsSummaryState variable,
    ServerDiagnosticsSummaryDataType value,
    object dataLock)
    : base(dataLock)
  {
    this.m_value = value;
    if (this.m_value == null)
      this.m_value = new ServerDiagnosticsSummaryDataType();
    this.Initialize(variable);
  }

  public ServerDiagnosticsSummaryState Variable => this.m_variable;

  public ServerDiagnosticsSummaryDataType Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  private void Initialize(ServerDiagnosticsSummaryState variable)
  {
    lock (this.Lock)
    {
      this.m_variable = variable;
      variable.Value = this.m_value;
      variable.OnReadValue = new NodeValueEventHandler(this.OnReadValue);
      variable.OnWriteValue = new NodeValueEventHandler(this.OnWriteValue);
      List<BaseInstanceState> updateList = new List<BaseInstanceState>();
      updateList.Add((BaseInstanceState) variable);
      BaseVariableState serverViewCount = (BaseVariableState) this.m_variable.ServerViewCount;
      if (serverViewCount != null)
      {
        serverViewCount.OnReadValue = new NodeValueEventHandler(this.OnRead_ServerViewCount);
        serverViewCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_ServerViewCount);
        updateList.Add((BaseInstanceState) serverViewCount);
      }
      BaseVariableState currentSessionCount = (BaseVariableState) this.m_variable.CurrentSessionCount;
      if (currentSessionCount != null)
      {
        currentSessionCount.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentSessionCount);
        currentSessionCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentSessionCount);
        updateList.Add((BaseInstanceState) currentSessionCount);
      }
      BaseVariableState cumulatedSessionCount = (BaseVariableState) this.m_variable.CumulatedSessionCount;
      if (cumulatedSessionCount != null)
      {
        cumulatedSessionCount.OnReadValue = new NodeValueEventHandler(this.OnRead_CumulatedSessionCount);
        cumulatedSessionCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CumulatedSessionCount);
        updateList.Add((BaseInstanceState) cumulatedSessionCount);
      }
      BaseVariableState rejectedSessionCount1 = (BaseVariableState) this.m_variable.SecurityRejectedSessionCount;
      if (rejectedSessionCount1 != null)
      {
        rejectedSessionCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_SecurityRejectedSessionCount);
        rejectedSessionCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SecurityRejectedSessionCount);
        updateList.Add((BaseInstanceState) rejectedSessionCount1);
      }
      BaseVariableState rejectedSessionCount2 = (BaseVariableState) this.m_variable.RejectedSessionCount;
      if (rejectedSessionCount2 != null)
      {
        rejectedSessionCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_RejectedSessionCount);
        rejectedSessionCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RejectedSessionCount);
        updateList.Add((BaseInstanceState) rejectedSessionCount2);
      }
      BaseVariableState sessionTimeoutCount = (BaseVariableState) this.m_variable.SessionTimeoutCount;
      if (sessionTimeoutCount != null)
      {
        sessionTimeoutCount.OnReadValue = new NodeValueEventHandler(this.OnRead_SessionTimeoutCount);
        sessionTimeoutCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SessionTimeoutCount);
        updateList.Add((BaseInstanceState) sessionTimeoutCount);
      }
      BaseVariableState sessionAbortCount = (BaseVariableState) this.m_variable.SessionAbortCount;
      if (sessionAbortCount != null)
      {
        sessionAbortCount.OnReadValue = new NodeValueEventHandler(this.OnRead_SessionAbortCount);
        sessionAbortCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SessionAbortCount);
        updateList.Add((BaseInstanceState) sessionAbortCount);
      }
      BaseVariableState subscriptionCount1 = (BaseVariableState) this.m_variable.CurrentSubscriptionCount;
      if (subscriptionCount1 != null)
      {
        subscriptionCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_CurrentSubscriptionCount);
        subscriptionCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CurrentSubscriptionCount);
        updateList.Add((BaseInstanceState) subscriptionCount1);
      }
      BaseVariableState subscriptionCount2 = (BaseVariableState) this.m_variable.CumulatedSubscriptionCount;
      if (subscriptionCount2 != null)
      {
        subscriptionCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_CumulatedSubscriptionCount);
        subscriptionCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_CumulatedSubscriptionCount);
        updateList.Add((BaseInstanceState) subscriptionCount2);
      }
      BaseVariableState publishingIntervalCount = (BaseVariableState) this.m_variable.PublishingIntervalCount;
      if (publishingIntervalCount != null)
      {
        publishingIntervalCount.OnReadValue = new NodeValueEventHandler(this.OnRead_PublishingIntervalCount);
        publishingIntervalCount.OnWriteValue = new NodeValueEventHandler(this.OnWrite_PublishingIntervalCount);
        updateList.Add((BaseInstanceState) publishingIntervalCount);
      }
      BaseVariableState rejectedRequestsCount1 = (BaseVariableState) this.m_variable.SecurityRejectedRequestsCount;
      if (rejectedRequestsCount1 != null)
      {
        rejectedRequestsCount1.OnReadValue = new NodeValueEventHandler(this.OnRead_SecurityRejectedRequestsCount);
        rejectedRequestsCount1.OnWriteValue = new NodeValueEventHandler(this.OnWrite_SecurityRejectedRequestsCount);
        updateList.Add((BaseInstanceState) rejectedRequestsCount1);
      }
      BaseVariableState rejectedRequestsCount2 = (BaseVariableState) this.m_variable.RejectedRequestsCount;
      if (rejectedRequestsCount2 != null)
      {
        rejectedRequestsCount2.OnReadValue = new NodeValueEventHandler(this.OnRead_RejectedRequestsCount);
        rejectedRequestsCount2.OnWriteValue = new NodeValueEventHandler(this.OnWrite_RejectedRequestsCount);
        updateList.Add((BaseInstanceState) rejectedRequestsCount2);
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
      ServerDiagnosticsSummaryDataType newValue = !(value is ExtensionObject extensionObject) ? (ServerDiagnosticsSummaryDataType) value : (ServerDiagnosticsSummaryDataType) extensionObject.Body;
      if (!Utils.IsEqual((object) this.m_value, (object) newValue))
      {
        this.UpdateChildrenChangeMasks(context, ref newValue, ref statusCode, ref timestamp);
        this.Timestamp = timestamp;
        this.m_value = (ServerDiagnosticsSummaryDataType) this.Write((object) newValue);
        this.m_variable.UpdateChangeMasks(NodeStateChangeMasks.Value);
      }
    }
    return ServiceResult.Good;
  }

  private void UpdateChildrenChangeMasks(
    ISystemContext context,
    ref ServerDiagnosticsSummaryDataType newValue,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    if (!Utils.IsEqual((object) this.m_value.ServerViewCount, (object) newValue.ServerViewCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ServerViewCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentSessionCount, (object) newValue.CurrentSessionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSessionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CumulatedSessionCount, (object) newValue.CumulatedSessionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CumulatedSessionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SecurityRejectedSessionCount, (object) newValue.SecurityRejectedSessionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityRejectedSessionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.RejectedSessionCount, (object) newValue.RejectedSessionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RejectedSessionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SessionTimeoutCount, (object) newValue.SessionTimeoutCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionTimeoutCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SessionAbortCount, (object) newValue.SessionAbortCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionAbortCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CurrentSubscriptionCount, (object) newValue.CurrentSubscriptionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSubscriptionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.CumulatedSubscriptionCount, (object) newValue.CumulatedSubscriptionCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CumulatedSubscriptionCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.PublishingIntervalCount, (object) newValue.PublishingIntervalCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingIntervalCount, ref statusCode, ref timestamp);
    if (!Utils.IsEqual((object) this.m_value.SecurityRejectedRequestsCount, (object) newValue.SecurityRejectedRequestsCount))
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityRejectedRequestsCount, ref statusCode, ref timestamp);
    if (Utils.IsEqual((object) this.m_value.RejectedRequestsCount, (object) newValue.RejectedRequestsCount))
      return;
    this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RejectedRequestsCount, ref statusCode, ref timestamp);
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

  private ServiceResult OnRead_ServerViewCount(
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
      BaseDataVariableState<uint> serverViewCount = this.m_variable?.ServerViewCount;
      if (serverViewCount != null && StatusCode.IsBad(serverViewCount.StatusCode))
      {
        value = (object) null;
        statusCode = serverViewCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.ServerViewCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (serverViewCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = serverViewCount.Timestamp;
        if (statusCode != serverViewCount.StatusCode)
        {
          statusCode = serverViewCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_ServerViewCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.ServerViewCount, ref statusCode, ref timestamp);
      this.m_value.ServerViewCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentSessionCount(
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
      BaseDataVariableState<uint> currentSessionCount = this.m_variable?.CurrentSessionCount;
      if (currentSessionCount != null && StatusCode.IsBad(currentSessionCount.StatusCode))
      {
        value = (object) null;
        statusCode = currentSessionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentSessionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (currentSessionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = currentSessionCount.Timestamp;
        if (statusCode != currentSessionCount.StatusCode)
        {
          statusCode = currentSessionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentSessionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSessionCount, ref statusCode, ref timestamp);
      this.m_value.CurrentSessionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CumulatedSessionCount(
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
      BaseDataVariableState<uint> cumulatedSessionCount = this.m_variable?.CumulatedSessionCount;
      if (cumulatedSessionCount != null && StatusCode.IsBad(cumulatedSessionCount.StatusCode))
      {
        value = (object) null;
        statusCode = cumulatedSessionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CumulatedSessionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (cumulatedSessionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = cumulatedSessionCount.Timestamp;
        if (statusCode != cumulatedSessionCount.StatusCode)
        {
          statusCode = cumulatedSessionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CumulatedSessionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CumulatedSessionCount, ref statusCode, ref timestamp);
      this.m_value.CumulatedSessionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SecurityRejectedSessionCount(
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
      BaseDataVariableState<uint> rejectedSessionCount = this.m_variable?.SecurityRejectedSessionCount;
      if (rejectedSessionCount != null && StatusCode.IsBad(rejectedSessionCount.StatusCode))
      {
        value = (object) null;
        statusCode = rejectedSessionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SecurityRejectedSessionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (rejectedSessionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = rejectedSessionCount.Timestamp;
        if (statusCode != rejectedSessionCount.StatusCode)
        {
          statusCode = rejectedSessionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SecurityRejectedSessionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityRejectedSessionCount, ref statusCode, ref timestamp);
      this.m_value.SecurityRejectedSessionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RejectedSessionCount(
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
      BaseDataVariableState<uint> rejectedSessionCount = this.m_variable?.RejectedSessionCount;
      if (rejectedSessionCount != null && StatusCode.IsBad(rejectedSessionCount.StatusCode))
      {
        value = (object) null;
        statusCode = rejectedSessionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RejectedSessionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (rejectedSessionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = rejectedSessionCount.Timestamp;
        if (statusCode != rejectedSessionCount.StatusCode)
        {
          statusCode = rejectedSessionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RejectedSessionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RejectedSessionCount, ref statusCode, ref timestamp);
      this.m_value.RejectedSessionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SessionTimeoutCount(
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
      BaseDataVariableState<uint> sessionTimeoutCount = this.m_variable?.SessionTimeoutCount;
      if (sessionTimeoutCount != null && StatusCode.IsBad(sessionTimeoutCount.StatusCode))
      {
        value = (object) null;
        statusCode = sessionTimeoutCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SessionTimeoutCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (sessionTimeoutCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = sessionTimeoutCount.Timestamp;
        if (statusCode != sessionTimeoutCount.StatusCode)
        {
          statusCode = sessionTimeoutCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SessionTimeoutCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionTimeoutCount, ref statusCode, ref timestamp);
      this.m_value.SessionTimeoutCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SessionAbortCount(
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
      BaseDataVariableState<uint> sessionAbortCount = this.m_variable?.SessionAbortCount;
      if (sessionAbortCount != null && StatusCode.IsBad(sessionAbortCount.StatusCode))
      {
        value = (object) null;
        statusCode = sessionAbortCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SessionAbortCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (sessionAbortCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = sessionAbortCount.Timestamp;
        if (statusCode != sessionAbortCount.StatusCode)
        {
          statusCode = sessionAbortCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SessionAbortCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SessionAbortCount, ref statusCode, ref timestamp);
      this.m_value.SessionAbortCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CurrentSubscriptionCount(
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
      BaseDataVariableState<uint> subscriptionCount = this.m_variable?.CurrentSubscriptionCount;
      if (subscriptionCount != null && StatusCode.IsBad(subscriptionCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CurrentSubscriptionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionCount.Timestamp;
        if (statusCode != subscriptionCount.StatusCode)
        {
          statusCode = subscriptionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CurrentSubscriptionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CurrentSubscriptionCount, ref statusCode, ref timestamp);
      this.m_value.CurrentSubscriptionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_CumulatedSubscriptionCount(
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
      BaseDataVariableState<uint> subscriptionCount = this.m_variable?.CumulatedSubscriptionCount;
      if (subscriptionCount != null && StatusCode.IsBad(subscriptionCount.StatusCode))
      {
        value = (object) null;
        statusCode = subscriptionCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.CumulatedSubscriptionCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (subscriptionCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = subscriptionCount.Timestamp;
        if (statusCode != subscriptionCount.StatusCode)
        {
          statusCode = subscriptionCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_CumulatedSubscriptionCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.CumulatedSubscriptionCount, ref statusCode, ref timestamp);
      this.m_value.CumulatedSubscriptionCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_PublishingIntervalCount(
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
      BaseDataVariableState<uint> publishingIntervalCount = this.m_variable?.PublishingIntervalCount;
      if (publishingIntervalCount != null && StatusCode.IsBad(publishingIntervalCount.StatusCode))
      {
        value = (object) null;
        statusCode = publishingIntervalCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.PublishingIntervalCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (publishingIntervalCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = publishingIntervalCount.Timestamp;
        if (statusCode != publishingIntervalCount.StatusCode)
        {
          statusCode = publishingIntervalCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_PublishingIntervalCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.PublishingIntervalCount, ref statusCode, ref timestamp);
      this.m_value.PublishingIntervalCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_SecurityRejectedRequestsCount(
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
      BaseDataVariableState<uint> rejectedRequestsCount = this.m_variable?.SecurityRejectedRequestsCount;
      if (rejectedRequestsCount != null && StatusCode.IsBad(rejectedRequestsCount.StatusCode))
      {
        value = (object) null;
        statusCode = rejectedRequestsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.SecurityRejectedRequestsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (rejectedRequestsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = rejectedRequestsCount.Timestamp;
        if (statusCode != rejectedRequestsCount.StatusCode)
        {
          statusCode = rejectedRequestsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_SecurityRejectedRequestsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.SecurityRejectedRequestsCount, ref statusCode, ref timestamp);
      this.m_value.SecurityRejectedRequestsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }

  private ServiceResult OnRead_RejectedRequestsCount(
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
      BaseDataVariableState<uint> rejectedRequestsCount = this.m_variable?.RejectedRequestsCount;
      if (rejectedRequestsCount != null && StatusCode.IsBad(rejectedRequestsCount.StatusCode))
      {
        value = (object) null;
        statusCode = rejectedRequestsCount.StatusCode;
        return new ServiceResult(statusCode);
      }
      if (this.m_value != null)
        value = (object) this.m_value.RejectedRequestsCount;
      ServiceResult status = this.Read(context, node, indexRange, dataEncoding, ref value, ref statusCode, ref timestamp);
      if (rejectedRequestsCount != null && ServiceResult.IsNotBad(status))
      {
        timestamp = rejectedRequestsCount.Timestamp;
        if (statusCode != rejectedRequestsCount.StatusCode)
        {
          statusCode = rejectedRequestsCount.StatusCode;
          status = new ServiceResult(statusCode);
        }
      }
      return status;
    }
  }

  private ServiceResult OnWrite_RejectedRequestsCount(
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
      this.UpdateChildVariableStatus((BaseVariableState) this.m_variable.RejectedRequestsCount, ref statusCode, ref timestamp);
      this.m_value.RejectedRequestsCount = (uint) this.Write(value);
      this.UpdateParent(context, ref statusCode, ref timestamp);
    }
    return ServiceResult.Good;
  }
}
