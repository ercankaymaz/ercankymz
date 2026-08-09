using System;

namespace QUT.GplexBuffers;

[Serializable]
public class BufferException : Exception
{
	public BufferException()
	{
	}

	public BufferException(string message)
		: base(message)
	{
	}

	public BufferException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
