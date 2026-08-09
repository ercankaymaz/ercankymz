using System;

namespace Xbim.IO.Step21;

public class XbimP21EofException : Exception
{
	public XbimP21EofException()
		: base($"Unexpected end of buffer.")
	{
	}
}
