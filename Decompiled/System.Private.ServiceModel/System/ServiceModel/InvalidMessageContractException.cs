using System.Runtime.Serialization;

namespace System.ServiceModel;

[Serializable]
public class InvalidMessageContractException : Exception
{
	public InvalidMessageContractException()
	{
	}

	public InvalidMessageContractException(string message)
		: base(message)
	{
	}

	public InvalidMessageContractException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected InvalidMessageContractException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
