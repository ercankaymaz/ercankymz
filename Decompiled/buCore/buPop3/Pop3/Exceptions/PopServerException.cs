namespace buPop3.Pop3.Exceptions;

public class PopServerException : PopClientException
{
	public PopServerException(string message)
		: base(message)
	{
	}
}
