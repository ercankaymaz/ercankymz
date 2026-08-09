namespace buPop3.Pop3.Exceptions;

public class LoginDelayException : PopClientException
{
	public LoginDelayException(PopServerException innerException)
		: base("Login denied because of recent connection to this maildrop. Increase time between connections.", innerException)
	{
	}
}
