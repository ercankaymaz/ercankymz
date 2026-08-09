using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CloseSequenceResponseInfo
{
	public UniqueId Identifier { get; set; }

	public UniqueId RelatesTo { get; set; }

	public static CloseSequenceResponseInfo ReadMessage(MessageVersion messageVersion, Message message, MessageHeaders headers)
	{
		if (headers.RelatesTo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.Format(System.SR.MissingRelatesToOnWsrmResponseReason, DXD.Wsrm11Dictionary.CloseSequenceResponse), messageVersion.Addressing.Namespace, "RelatesTo", isDuplicate: false));
		}
		if (message.IsEmpty)
		{
			string message2 = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(message2));
		}
		CloseSequenceResponseInfo closeSequenceResponseInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			closeSequenceResponseInfo = CloseSequenceResponse.Create(reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		closeSequenceResponseInfo.RelatesTo = headers.RelatesTo;
		return closeSequenceResponseInfo;
	}
}
