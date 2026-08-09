using System;
using System.Runtime.Serialization;

namespace ACadSharp.Exceptions;

[Serializable]
public class DwgException : Exception
{
	public DwgException(string message)
		: base(message)
	{
	}

	public DwgException(string message, Exception inner)
		: base(message, inner)
	{
	}

	protected DwgException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
