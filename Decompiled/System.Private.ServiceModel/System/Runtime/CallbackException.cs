namespace System.Runtime;

internal class CallbackException : FatalException
{
	public CallbackException()
	{
	}

	public CallbackException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
