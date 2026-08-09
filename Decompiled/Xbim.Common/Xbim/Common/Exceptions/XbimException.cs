using System;

namespace Xbim.Common.Exceptions;

public class XbimException : Exception
{
	public XbimException()
	{
	}

	public XbimException(string message)
		: base(message)
	{
	}

	public XbimException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
