using System;
using System.Runtime.Serialization;

namespace devDept;

[Serializable]
public class EyeshotMemoryLeakException : EyeshotException
{
	protected EyeshotMemoryLeakException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public EyeshotMemoryLeakException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public EyeshotMemoryLeakException(string message)
		: base(message)
	{
	}

	public EyeshotMemoryLeakException()
	{
	}
}
