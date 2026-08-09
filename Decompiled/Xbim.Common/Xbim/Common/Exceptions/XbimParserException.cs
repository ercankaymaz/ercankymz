using System;

namespace Xbim.Common.Exceptions;

public class XbimParserException : XbimException
{
	public XbimParserException()
	{
	}

	public XbimParserException(string message)
		: base(message)
	{
	}

	public XbimParserException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
