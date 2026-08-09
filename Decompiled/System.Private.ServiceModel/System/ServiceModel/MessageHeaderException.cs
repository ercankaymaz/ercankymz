using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

[Serializable]
public class MessageHeaderException : ProtocolException
{
	public string HeaderName { get; }

	public string HeaderNamespace { get; }

	public bool IsDuplicate { get; }

	public MessageHeaderException(string message)
		: this(message, null, null)
	{
	}

	public MessageHeaderException(string message, bool isDuplicate)
		: this(message, null, null, isDuplicate, null)
	{
	}

	public MessageHeaderException(string message, Exception innerException)
		: this(message, null, null, innerException)
	{
	}

	public MessageHeaderException(string message, string headerName, string ns)
		: this(message, headerName, ns, null)
	{
	}

	public MessageHeaderException(string message, string headerName, string ns, bool isDuplicate)
		: this(message, headerName, ns, isDuplicate, null)
	{
	}

	public MessageHeaderException(string message, string headerName, string ns, Exception innerException)
		: this(message, headerName, ns, isDuplicate: false, innerException)
	{
	}

	public MessageHeaderException(string message, string headerName, string ns, bool isDuplicate, Exception innerException)
		: base(message, innerException)
	{
		HeaderName = headerName;
		HeaderNamespace = ns;
		IsDuplicate = isDuplicate;
	}

	internal Message ProvideFault(MessageVersion messageVersion)
	{
		WSAddressing10ProblemHeaderQNameFault wSAddressing10ProblemHeaderQNameFault = new WSAddressing10ProblemHeaderQNameFault(this);
		Message message = System.ServiceModel.Channels.Message.CreateMessage(messageVersion, wSAddressing10ProblemHeaderQNameFault, AddressingVersion.WSAddressing10.FaultAction);
		wSAddressing10ProblemHeaderQNameFault.AddHeaders(message.Headers);
		return message;
	}

	public MessageHeaderException()
	{
	}

	protected MessageHeaderException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
