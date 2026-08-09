using System;
using System.Runtime.Serialization;

namespace devDept;

[Serializable]
public class GraphicsException : EyeshotException
{
	protected GraphicsException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public GraphicsException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public GraphicsException(string message)
		: base(message)
	{
	}

	public GraphicsException()
	{
	}
}
