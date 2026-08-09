using System;
using DSTV.Net.Implementations;

namespace DSTV.Net.Exceptions;

public class UnexpectedEndException : ParseException
{
	public UnexpectedEndException(ReaderContext context)
		: base(context, "Unexpected end encountered. The file should end with 'EN'")
	{
	}

	protected UnexpectedEndException(ReaderContext context, string message)
		: base(context, message)
	{
	}

	protected UnexpectedEndException()
	{
	}

	protected UnexpectedEndException(string? message)
		: base(message)
	{
	}

	protected UnexpectedEndException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
