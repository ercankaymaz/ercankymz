using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class TerminateSequenceResponseInfo
{
	public UniqueId Identifier { get; set; }

	public UniqueId RelatesTo { get; set; }

	public static TerminateSequenceResponseInfo ReadMessage(MessageVersion messageVersion, Message message, MessageHeaders headers)
	{
		if (headers.RelatesTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MissingRelatesToOnWsrmResponseReason, DXD.Wsrm11Dictionary.TerminateSequenceResponse), messageVersion.Addressing.Namespace, "RelatesTo", isDuplicate: false));
		}
		if (message.IsEmpty)
		{
			string message2 = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, WsrmIndex.GetTerminateSequenceResponseActionString(ReliableMessagingVersion.WSReliableMessaging11));
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(message2));
		}
		TerminateSequenceResponseInfo terminateSequenceResponseInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			terminateSequenceResponseInfo = TerminateSequenceResponse.Create(reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		terminateSequenceResponseInfo.RelatesTo = headers.RelatesTo;
		return terminateSequenceResponseInfo;
	}
}
