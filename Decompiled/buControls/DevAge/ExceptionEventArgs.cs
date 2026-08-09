using System;

namespace DevAge;

public class ExceptionEventArgs : EventArgs
{
	private Exception ex;

	public Exception Exception => ex;

	public ExceptionEventArgs(Exception ex)
	{
		this.ex = ex;
	}
}
