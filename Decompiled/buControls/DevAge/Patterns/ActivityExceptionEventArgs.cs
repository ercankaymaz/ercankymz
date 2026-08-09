using System;

namespace DevAge.Patterns;

public class ActivityExceptionEventArgs : ActivityEventArgs
{
	private Exception exception;

	public Exception Exception
	{
		get
		{
			return exception;
		}
		set
		{
			exception = value;
		}
	}

	public ActivityExceptionEventArgs(IActivity activity, Exception exception)
		: base(activity)
	{
		this.exception = exception;
	}
}
