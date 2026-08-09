using System;

namespace Xbim.Common.Exceptions;

public class XbimInitializationFailedException : Exception
{
	public XbimInitializationFailedException()
	{
	}

	public XbimInitializationFailedException(string message)
		: base(message)
	{
	}

	public XbimInitializationFailedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
