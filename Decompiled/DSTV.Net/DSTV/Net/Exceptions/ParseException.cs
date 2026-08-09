using System;
using DSTV.Net.Implementations;

namespace DSTV.Net.Exceptions;

public abstract class ParseException : Exception
{
	private readonly ReaderContext? _context;

	public int? LineNumber => _context?.LineNumber;

	protected ParseException(ReaderContext context)
	{
		_context = context;
	}

	protected ParseException(ReaderContext context, string message)
		: base(message)
	{
		_context = context;
	}

	protected ParseException()
	{
	}

	protected ParseException(string? message)
		: base(message)
	{
	}

	protected ParseException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
