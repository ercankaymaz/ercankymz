// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.MonitoredItemDataCache
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemDataCache
{
  private int m_queueSize;
  private DataValue m_lastValue;
  private readonly Queue<DataValue> m_values;

  public MonitoredItemDataCache(int queueSize)
  {
    this.m_queueSize = queueSize;
    this.m_values = new Queue<DataValue>();
  }

  public int QueueSize => this.m_queueSize;

  public DataValue LastValue => this.m_lastValue;

  public IList<DataValue> Publish()
  {
    DataValue[] dataValueArray = new DataValue[this.m_values.Count];
    for (int index = 0; index < dataValueArray.Length; ++index)
      dataValueArray[index] = this.m_values.Dequeue();
    return (IList<DataValue>) dataValueArray;
  }

  public void OnNotification(MonitoredItemNotification notification)
  {
    this.m_values.Enqueue(notification.Value);
    this.m_lastValue = notification.Value;
    CoreClientUtils.EventLog.NotificationValue(notification.ClientHandle, this.m_lastValue.WrappedValue);
    while (this.m_values.Count > this.m_queueSize)
      this.m_values.Dequeue();
  }

  public void SetQueueSize(int queueSize)
  {
    if (queueSize == this.m_queueSize)
      return;
    if (queueSize < 1)
      queueSize = 1;
    this.m_queueSize = queueSize;
    while (this.m_values.Count > this.m_queueSize)
      this.m_values.Dequeue();
  }
}
