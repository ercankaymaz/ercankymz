using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class BrowserEventArgs : EventArgs
{
	private bool m_cancel;

	private bool m_continueUntilDone;

	private ReferenceDescriptionCollection m_references;

	public bool Cancel
	{
		get
		{
			return m_cancel;
		}
		set
		{
			m_cancel = value;
		}
	}

	public bool ContinueUntilDone
	{
		get
		{
			return m_continueUntilDone;
		}
		set
		{
			m_continueUntilDone = value;
		}
	}

	public ReferenceDescriptionCollection References => m_references;

	internal BrowserEventArgs(ReferenceDescriptionCollection references)
	{
		m_references = references;
	}
}
