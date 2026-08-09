using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class PublishStateChangedEventArgs : EventArgs
{
	private readonly PublishStateChangedMask m_changeMask;

	public PublishStateChangedMask Status => m_changeMask;

	internal PublishStateChangedEventArgs(PublishStateChangedMask changeMask)
	{
		m_changeMask = changeMask;
	}
}
