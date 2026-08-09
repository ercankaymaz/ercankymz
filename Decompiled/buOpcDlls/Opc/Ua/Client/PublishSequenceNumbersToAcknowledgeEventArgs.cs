using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class PublishSequenceNumbersToAcknowledgeEventArgs : EventArgs
{
	private readonly SubscriptionAcknowledgementCollection m_acknowledgementsToSend;

	private readonly SubscriptionAcknowledgementCollection m_deferredAcknowledgementsToSend;

	public SubscriptionAcknowledgementCollection AcknowledgementsToSend => m_acknowledgementsToSend;

	public SubscriptionAcknowledgementCollection DeferredAcknowledgementsToSend => m_deferredAcknowledgementsToSend;

	internal PublishSequenceNumbersToAcknowledgeEventArgs(SubscriptionAcknowledgementCollection acknowledgementsToSend, SubscriptionAcknowledgementCollection deferredAcknowledgementsToSend)
	{
		m_acknowledgementsToSend = acknowledgementsToSend;
		m_deferredAcknowledgementsToSend = deferredAcknowledgementsToSend;
	}
}
