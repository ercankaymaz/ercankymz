using System.Runtime.Serialization;

namespace System.IdentityModel;

[Serializable]
public class SecurityMessageSerializationException : Exception
{
	public SecurityMessageSerializationException()
	{
	}

	public SecurityMessageSerializationException(string message)
		: base(message)
	{
	}

	public SecurityMessageSerializationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SecurityMessageSerializationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
