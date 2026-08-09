using System;
using System.Globalization;
using DSTV.Net.Implementations;

namespace DSTV.Net.Exceptions;

public class UnexpectedCharacterException : ParseException
{
	public UnexpectedCharacterException(ReaderContext context, char expected, char actual)
		: base(context, string.Format(CultureInfo.InvariantCulture, "Expected character '{1}' at lineNumber {0}, but retrieved character '{2}' instead.", context?.LineNumber, expected, actual))
	{
	}

	protected UnexpectedCharacterException(ReaderContext context)
		: base(context)
	{
	}

	protected UnexpectedCharacterException(ReaderContext context, string message)
		: base(context, message)
	{
	}

	protected UnexpectedCharacterException()
	{
	}

	protected UnexpectedCharacterException(string? message)
		: base(message)
	{
	}

	protected UnexpectedCharacterException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
