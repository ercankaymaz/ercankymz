using System;
using DSTV.Net.Implementations;

namespace DSTV.Net.Exceptions;

public class MissingStartOfFileException : ParseException
{
	public MissingStartOfFileException(ReaderContext context)
		: base(context)
	{
	}

	protected MissingStartOfFileException(ReaderContext context, string message)
		: base(context, message)
	{
	}

	protected MissingStartOfFileException()
	{
	}

	protected MissingStartOfFileException(string? message)
		: base(message)
	{
	}

	protected MissingStartOfFileException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
