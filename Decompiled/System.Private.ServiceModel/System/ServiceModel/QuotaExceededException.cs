using System.Runtime.Serialization;

namespace System.ServiceModel;

[Serializable]
public class QuotaExceededException : Exception
{
	public QuotaExceededException()
	{
	}

	public QuotaExceededException(string message)
		: base(message)
	{
	}

	public QuotaExceededException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected QuotaExceededException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
