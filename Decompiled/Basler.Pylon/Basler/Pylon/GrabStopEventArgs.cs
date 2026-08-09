using System;

namespace Basler.Pylon;

public class GrabStopEventArgs : EventArgs
{
	private GrabStopReason m_reason;

	private string m_errorMessage;

	public string ErrorMessage => m_errorMessage;

	public GrabStopReason Reason => m_reason;

	public GrabStopEventArgs(GrabStopReason reason, string errorMessage)
	{
		m_reason = reason;
		m_errorMessage = errorMessage;
		base._002Ector();
	}

	public GrabStopEventArgs()
	{
		m_reason = GrabStopReason.UserRequest;
		m_errorMessage = string.Empty;
		base._002Ector();
	}
}
