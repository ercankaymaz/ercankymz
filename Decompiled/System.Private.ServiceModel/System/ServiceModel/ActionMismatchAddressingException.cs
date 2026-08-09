using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

[Serializable]
internal class ActionMismatchAddressingException : ProtocolException
{
	public string HttpActionHeader { get; }

	public string SoapActionHeader { get; }

	public ActionMismatchAddressingException(string message, string soapActionHeader, string httpActionHeader)
		: base(message)
	{
		HttpActionHeader = httpActionHeader;
		SoapActionHeader = soapActionHeader;
	}

	protected ActionMismatchAddressingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal Message ProvideFault(MessageVersion messageVersion)
	{
		WSAddressing10ProblemHeaderQNameFault wSAddressing10ProblemHeaderQNameFault = new WSAddressing10ProblemHeaderQNameFault(this);
		Message message = System.ServiceModel.Channels.Message.CreateMessage(messageVersion, wSAddressing10ProblemHeaderQNameFault, messageVersion.Addressing.FaultAction);
		wSAddressing10ProblemHeaderQNameFault.AddHeaders(message.Headers);
		return message;
	}
}
