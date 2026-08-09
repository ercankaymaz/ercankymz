namespace buPop3.Pop3.Exceptions;

public class PopServerLockedException : PopClientException
{
	public PopServerLockedException(PopServerException innerException)
		: base("The account is locked or in use", innerException)
	{
	}
}
