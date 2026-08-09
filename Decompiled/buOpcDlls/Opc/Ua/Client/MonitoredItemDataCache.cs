using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemDataCache
{
	private int m_queueSize;

	private DataValue m_lastValue;

	private readonly Queue<DataValue> m_values;

	public int QueueSize => m_queueSize;

	public DataValue LastValue => m_lastValue;

	public MonitoredItemDataCache(int queueSize)
	{
		m_queueSize = queueSize;
		m_values = new Queue<DataValue>();
	}

	public IList<DataValue> Publish()
	{
		DataValue[] array = new DataValue[m_values.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = m_values.Dequeue();
		}
		return array;
	}

	public void OnNotification(MonitoredItemNotification notification)
	{
		m_values.Enqueue(notification.Value);
		m_lastValue = notification.Value;
		CoreClientUtils.EventLog.NotificationValue(notification.ClientHandle, m_lastValue.WrappedValue);
		while (m_values.Count > m_queueSize)
		{
			m_values.Dequeue();
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
			while (m_values.Count > m_queueSize)
			{
				m_values.Dequeue();
			}
		}
	}
}
