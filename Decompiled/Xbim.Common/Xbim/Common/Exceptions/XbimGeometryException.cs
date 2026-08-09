using System;

namespace Xbim.Common.Exceptions;

public class XbimGeometryException : XbimException
{
	public XbimGeometryException()
	{
	}

	public XbimGeometryException(string message)
		: base(message)
	{
	}

	public XbimGeometryException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
