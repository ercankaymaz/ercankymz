using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class SubscriptionStateChangedEventArgs : EventArgs
{
	private readonly SubscriptionChangeMask m_changeMask;

	public SubscriptionChangeMask Status => m_changeMask;

	internal SubscriptionStateChangedEventArgs(SubscriptionChangeMask changeMask)
	{
		m_changeMask = changeMask;
	}
}
