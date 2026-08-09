using System;

namespace Xbim.IO.Step21;

public class XbimP21InvalidCharacterException : Exception
{
	public XbimP21InvalidCharacterException(string message)
		: base(message)
	{
	}
}
