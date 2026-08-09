using System;

namespace Xbim.Common.Exceptions;

public class XbimGeometryFaceSetTooLargeException : XbimGeometryException
{
	public XbimGeometryFaceSetTooLargeException()
	{
	}

	public XbimGeometryFaceSetTooLargeException(string message)
		: base(message)
	{
	}

	public XbimGeometryFaceSetTooLargeException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
