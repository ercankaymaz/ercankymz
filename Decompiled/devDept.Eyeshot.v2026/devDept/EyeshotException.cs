using System;
using System.Runtime.Serialization;

namespace devDept;

[Serializable]
public class EyeshotException : Exception
{
	protected EyeshotException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public EyeshotException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public EyeshotException(string message)
		: base(message)
	{
	}

	public EyeshotException()
	{
	}
}
