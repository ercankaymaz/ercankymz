using System.Runtime.Serialization;

namespace System.ServiceModel.Security;

[Serializable]
internal class SessionKeyExpiredException : MessageSecurityException
{
	public SessionKeyExpiredException()
	{
	}

	public SessionKeyExpiredException(string message)
		: base(message)
	{
	}

	public SessionKeyExpiredException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SessionKeyExpiredException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
