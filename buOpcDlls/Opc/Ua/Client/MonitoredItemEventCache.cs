// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.MonitoredItemEventCache
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemEventCache
{
  private int m_queueSize;
  private EventFieldList m_lastEvent;
  private readonly Queue<EventFieldList> m_events;

  public MonitoredItemEventCache(int queueSize)
  {
    this.m_queueSize = queueSize;
    this.m_events = new Queue<EventFieldList>();
  }

  public int QueueSize => this.m_queueSize;

  public EventFieldList LastEvent => this.m_lastEvent;

  public IList<EventFieldList> Publish()
  {
    EventFieldList[] eventFieldListArray = new EventFieldList[this.m_events.Count];
    for (int index = 0; index < eventFieldListArray.Length; ++index)
      eventFieldListArray[index] = this.m_events.Dequeue();
    return (IList<EventFieldList>) eventFieldListArray;
  }

  public void OnNotification(EventFieldList notification)
  {
    this.m_events.Enqueue(notification);
    this.m_lastEvent = notification;
    while (this.m_events.Count > this.m_queueSize)
      this.m_events.Dequeue();
  }

  public void SetQueueSize(int queueSize)
  {
    if (queueSize == this.m_queueSize)
      return;
    if (queueSize < 1)
      queueSize = 1;
    this.m_queueSize = queueSize;
    while (this.m_events.Count > this.m_queueSize)
      this.m_events.Dequeue();
  }
}
