using System;
using System.Runtime.Serialization;

namespace UglyToad.PdfPig.Fonts;

[Serializable]
public class CorruptCompressedDataException : Exception
{
	public CorruptCompressedDataException()
	{
	}

	public CorruptCompressedDataException(string message)
		: base(message)
	{
	}

	public CorruptCompressedDataException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected CorruptCompressedDataException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
