using System.Runtime.Serialization;

namespace System.ServiceModel.Security;

[Serializable]
public class MessageSecurityException : CommunicationException
{
	public MessageSecurityException()
	{
	}

	public MessageSecurityException(string message)
		: base(message)
	{
	}

	public MessageSecurityException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected MessageSecurityException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
