using System.Runtime.Serialization;

namespace System.ServiceModel.Security;

[Serializable]
public class SecurityNegotiationException : CommunicationException
{
	public SecurityNegotiationException()
	{
	}

	public SecurityNegotiationException(string message)
		: base(message)
	{
	}

	public SecurityNegotiationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SecurityNegotiationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
