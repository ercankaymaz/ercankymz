using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class MonitoredItemNotificationEventArgs : EventArgs
{
	private readonly IEncodeable m_notificationValue;

	public IEncodeable NotificationValue => m_notificationValue;

	internal MonitoredItemNotificationEventArgs(IEncodeable notificationValue)
	{
		m_notificationValue = notificationValue;
	}
}
