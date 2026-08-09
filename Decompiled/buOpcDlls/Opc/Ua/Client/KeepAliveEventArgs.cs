using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public class KeepAliveEventArgs : EventArgs
{
	private readonly ServiceResult m_status;

	private readonly ServerState m_currentState;

	private readonly DateTime m_currentTime;

	private bool m_cancelKeepAlive;

	public ServiceResult Status => m_status;

	public ServerState CurrentState => m_currentState;

	public DateTime CurrentTime => m_currentTime;

	public bool CancelKeepAlive
	{
		get
		{
			return m_cancelKeepAlive;
		}
		set
		{
			m_cancelKeepAlive = value;
		}
	}

	internal KeepAliveEventArgs(ServiceResult status, ServerState currentState, DateTime currentTime)
	{
		m_status = status;
		m_currentState = currentState;
		m_currentTime = currentTime;
	}
}
