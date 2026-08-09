using System;

namespace buPop3.Pop3.Exceptions;

public class PopServerNotAvailableException : PopClientException
{
	public PopServerNotAvailableException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
