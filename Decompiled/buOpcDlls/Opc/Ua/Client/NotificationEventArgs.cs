using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class NotificationEventArgs : EventArgs
{
	private readonly Subscription m_subscription;

	private readonly NotificationMessage m_notificationMessage;

	private readonly IList<string> m_stringTable;

	public Subscription Subscription => m_subscription;

	public NotificationMessage NotificationMessage => m_notificationMessage;

	public IList<string> StringTable => m_stringTable;

	internal NotificationEventArgs(Subscription subscription, NotificationMessage notificationMessage, IList<string> stringTable)
	{
		m_subscription = subscription;
		m_notificationMessage = notificationMessage;
		m_stringTable = stringTable;
	}
}
