using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemEventCache
{
	private int m_queueSize;

	private EventFieldList m_lastEvent;

	private readonly Queue<EventFieldList> m_events;

	public int QueueSize => m_queueSize;

	public EventFieldList LastEvent => m_lastEvent;

	public MonitoredItemEventCache(int queueSize)
	{
		m_queueSize = queueSize;
		m_events = new Queue<EventFieldList>();
	}

	public IList<EventFieldList> Publish()
	{
		EventFieldList[] array = new EventFieldList[m_events.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = m_events.Dequeue();
		}
		return array;
	}

	public void OnNotification(EventFieldList notification)
	{
		m_events.Enqueue(notification);
		m_lastEvent = notification;
		while (m_events.Count > m_queueSize)
		{
			m_events.Dequeue();
		}
	}

	public void SetQueueSize(int queueSize)
	{
		if (queueSize != m_queueSize)
		{
			if (queueSize < 1)
			{
				queueSize = 1;
			}
			m_queueSize = queueSize;
			while (m_events.Count > m_queueSize)
			{
				m_events.Dequeue();
			}
		}
	}
}
