namespace buPop3.Pop3.Exceptions;

public class InvalidUseException : PopClientException
{
	public InvalidUseException(string message)
		: base(message)
	{
	}
}
