using System;
using System.Runtime.Serialization;

namespace UglyToad.PdfPig.Fonts;

[Serializable]
public class InvalidFontFormatException : Exception
{
	public InvalidFontFormatException()
	{
	}

	public InvalidFontFormatException(string message)
		: base(message)
	{
	}

	public InvalidFontFormatException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected InvalidFontFormatException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
