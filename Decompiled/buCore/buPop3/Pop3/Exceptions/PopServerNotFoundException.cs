using System;

namespace buPop3.Pop3.Exceptions;

public class PopServerNotFoundException : PopClientException
{
	public PopServerNotFoundException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
