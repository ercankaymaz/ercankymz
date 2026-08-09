using System;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperException : Exception
{
	public ClipperException(string description)
		: base(description)
	{
	}
}
