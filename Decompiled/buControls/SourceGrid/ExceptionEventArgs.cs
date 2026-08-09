using System;

namespace SourceGrid;

public class ExceptionEventArgs : EventArgs
{
	private Exception p_Exception;

	private bool bool_0 = false;

	public Exception Exception => p_Exception;

	public bool Handled
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ExceptionEventArgs(Exception p_Exception)
	{
		this.p_Exception = p_Exception;
	}
}
