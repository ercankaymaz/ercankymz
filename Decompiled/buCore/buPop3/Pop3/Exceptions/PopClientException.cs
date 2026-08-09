using System;

namespace buPop3.Pop3.Exceptions;

public abstract class PopClientException : Exception
{
	protected PopClientException(string message, Exception innerException)
		: base(message, innerException)
	{
		if (message != null)
		{
			if (innerException == null)
			{
				throw new ArgumentNullException("innerException");
			}
			return;
		}
		throw new ArgumentNullException("message");
	}

	protected PopClientException(string message)
		: base(message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
	}
}
