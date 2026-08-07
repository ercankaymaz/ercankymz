// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseVariableValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseVariableValue
{
  public VariableValueEventHandler OnBeforeRead;
  public VariableValueEventHandler OnAfterWrite;
  private object m_lock;
  private VariableCopyPolicy m_copyPolicy;
  private BaseInstanceState[] m_updateList;
  private ServiceResult m_error;
  private DateTime m_timestamp;

  public BaseVariableValue(object dataLock)
  {
    this.m_lock = dataLock;
    this.m_copyPolicy = VariableCopyPolicy.CopyOnRead;
    if (this.m_lock != null)
      return;
    this.m_lock = new object();
  }

  public object Lock => this.m_lock;

  public VariableCopyPolicy CopyPolicy
  {
    get => this.m_copyPolicy;
    set => this.m_copyPolicy = value;
  }

  public ServiceResult Error
  {
    get => this.m_error;
    set => this.m_error = value;
  }

  public DateTime Timestamp
  {
    get => this.m_timestamp;
    set => this.m_timestamp = value;
  }

  public void ChangesComplete(ISystemContext context)
  {
    lock (this.m_lock)
    {
      if (this.m_updateList == null)
        return;
      for (int index = 0; index < this.m_updateList.Length; ++index)
      {
        BaseInstanceState update = this.m_updateList[index];
        if (update != null)
        {
          update.UpdateChangeMasks(NodeStateChangeMasks.Value);
          update.ClearChangeMasks(context, false);
        }
      }
    }
  }

  protected void DoBeforeReadProcessing(ISystemContext context, NodeState node)
  {
    if (this.OnBeforeRead == null)
      return;
    this.OnBeforeRead(context, this, node);
  }

  protected ServiceResult Read(
    ISystemContext context,
    NodeState node,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref StatusCode statusCode,
    ref DateTime timestamp)
  {
    lock (this.m_lock)
    {
      if (this.m_timestamp == DateTime.MinValue)
        this.m_timestamp = DateTime.UtcNow;
      timestamp = this.m_timestamp;
      if (ServiceResult.IsBad(this.m_error))
      {
        value = (object) null;
        statusCode = this.m_error.StatusCode;
        return this.m_error;
      }
      ServiceResult status = BaseVariableState.ApplyIndexRangeAndDataEncoding(context, indexRange, dataEncoding, ref value);
      if (ServiceResult.IsBad(status))
      {
        statusCode = status.StatusCode;
        return status;
      }
      if ((this.m_copyPolicy & VariableCopyPolicy.CopyOnRead) != VariableCopyPolicy.Never)
        value = Utils.Clone(value);
      statusCode = (StatusCode) 0U;
      return ServiceResult.Good;
    }
  }

  protected ServiceResult Read(object currentValue, ref object valueToRead)
  {
    lock (this.m_lock)
    {
      if (ServiceResult.IsBad(this.m_error))
      {
        valueToRead = (object) null;
        return this.m_error;
      }
      valueToRead = (this.m_copyPolicy & VariableCopyPolicy.CopyOnRead) == VariableCopyPolicy.Never ? currentValue : Utils.Clone(currentValue);
      return ServiceResult.Good;
    }
  }

  protected object Write(object valueToWrite)
  {
    lock (this.m_lock)
      return (this.m_copyPolicy & VariableCopyPolicy.CopyOnWrite) != VariableCopyPolicy.Never ? Utils.Clone(valueToWrite) : valueToWrite;
  }

  protected void SetUpdateList(IList<BaseInstanceState> updateList)
  {
    lock (this.m_lock)
    {
      this.m_updateList = (BaseInstanceState[]) null;
      if (updateList == null || updateList.Count <= 0)
        return;
      this.m_updateList = new BaseInstanceState[updateList.Count];
      for (int index = 0; index < this.m_updateList.Length; ++index)
      {
        this.m_updateList[index] = updateList[index];
        if (this.m_updateList[index] is BaseVariableState update)
          update.CopyPolicy = VariableCopyPolicy.Never;
      }
    }
  }
}
