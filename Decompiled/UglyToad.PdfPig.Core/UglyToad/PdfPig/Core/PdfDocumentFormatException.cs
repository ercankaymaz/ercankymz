using System;
using System.Runtime.Serialization;

namespace UglyToad.PdfPig.Core;

[Serializable]
public class PdfDocumentFormatException : Exception
{
	public PdfDocumentFormatException()
	{
	}

	public PdfDocumentFormatException(string message)
		: base(message)
	{
	}

	public PdfDocumentFormatException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected PdfDocumentFormatException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
