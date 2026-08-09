using System.Runtime.Serialization;

namespace System.ServiceModel.Security;

[Serializable]
public class SecurityAccessDeniedException : CommunicationException
{
	public SecurityAccessDeniedException(string message)
		: base(message)
	{
	}

	public SecurityAccessDeniedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SecurityAccessDeniedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
