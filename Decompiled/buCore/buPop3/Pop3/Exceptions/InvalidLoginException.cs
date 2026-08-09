using System;

namespace buPop3.Pop3.Exceptions;

public class InvalidLoginException : PopClientException
{
	public InvalidLoginException(Exception innerException)
		: base("Server did not accept user credentials", innerException)
	{
	}
}
