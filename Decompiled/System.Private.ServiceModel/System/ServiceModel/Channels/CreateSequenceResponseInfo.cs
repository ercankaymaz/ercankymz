using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CreateSequenceResponseInfo
{
	public EndpointAddress AcceptAcksTo { get; set; }

	public UniqueId Identifier { get; set; }

	public UniqueId RelatesTo { get; set; }

	public static CreateSequenceResponseInfo ReadMessage(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, Message message, MessageHeaders headers)
	{
		if (message.IsEmpty)
		{
			string message2 = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, WsrmIndex.GetCreateSequenceResponseActionString(reliableMessagingVersion));
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(message2));
		}
		if (headers.RelatesTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MissingRelatesToOnWsrmResponseReason, XD.WsrmFeb2005Dictionary.CreateSequenceResponse), messageVersion.Addressing.Namespace, "RelatesTo", isDuplicate: false));
		}
		CreateSequenceResponseInfo createSequenceResponseInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			createSequenceResponseInfo = CreateSequenceResponse.Create(messageVersion.Addressing, reliableMessagingVersion, reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		createSequenceResponseInfo.RelatesTo = headers.RelatesTo;
		return createSequenceResponseInfo;
	}
}
