using System.Runtime.Serialization;

namespace System.ServiceModel.Dispatcher;

[Serializable]
internal abstract class InvalidBodyAccessException : Exception
{
	protected InvalidBodyAccessException(string message)
		: this(message, null)
	{
	}

	protected InvalidBodyAccessException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected InvalidBodyAccessException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
