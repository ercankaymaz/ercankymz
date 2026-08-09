using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class WsrmRequestInfo
{
	public UniqueId MessageId { get; private set; }

	public EndpointAddress ReplyTo { get; private set; }

	public abstract string RequestName { get; }

	protected void SetMessageId(MessageVersion messageVersion, MessageHeaders headers)
	{
		MessageId = headers.MessageId;
		if (MessageId == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MissingMessageIdOnWsrmRequest, RequestName), messageVersion.Addressing.Namespace, "MessageID", isDuplicate: false));
		}
	}

	protected void SetReplyTo(MessageVersion messageVersion, MessageHeaders headers)
	{
		ReplyTo = headers.ReplyTo;
		if (messageVersion.Addressing == AddressingVersion.WSAddressing10 && ReplyTo == null)
		{
			ReplyTo = EndpointAddress.AnonymousAddress;
		}
		if (ReplyTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MissingReplyToOnWsrmRequest, RequestName), messageVersion.Addressing.Namespace, "ReplyTo", isDuplicate: false));
		}
	}
}
