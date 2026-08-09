using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

[Serializable]
public class ActionNotSupportedException : CommunicationException
{
	public ActionNotSupportedException()
	{
	}

	public ActionNotSupportedException(string message)
		: base(message)
	{
	}

	public ActionNotSupportedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected ActionNotSupportedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal Message ProvideFault(MessageVersion messageVersion)
	{
		FaultCode faultCode = FaultCode.CreateSenderFaultCode("ActionNotSupported", messageVersion.Addressing.Namespace);
		string message = Message;
		return System.ServiceModel.Channels.Message.CreateMessage(messageVersion, faultCode, message, messageVersion.Addressing.FaultAction);
	}
}
