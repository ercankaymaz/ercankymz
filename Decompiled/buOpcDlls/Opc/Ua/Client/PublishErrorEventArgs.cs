using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class PublishErrorEventArgs : EventArgs
{
	private readonly uint m_subscriptionId;

	private readonly uint m_sequenceNumber;

	private readonly ServiceResult m_status;

	public ServiceResult Status => m_status;

	public uint SubscriptionId => m_subscriptionId;

	public uint SequenceNumber => m_sequenceNumber;

	internal PublishErrorEventArgs(ServiceResult status)
	{
		m_status = status;
	}

	internal PublishErrorEventArgs(ServiceResult status, uint subscriptionId, uint sequenceNumber)
	{
		m_status = status;
		m_subscriptionId = subscriptionId;
		m_sequenceNumber = sequenceNumber;
	}
}
