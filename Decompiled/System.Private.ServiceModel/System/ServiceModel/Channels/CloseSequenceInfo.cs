using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CloseSequenceInfo : WsrmRequestInfo
{
	public UniqueId Identifier { get; set; }

	public long LastMsgNumber { get; set; }

	public override string RequestName => "CloseSequence";

	public static CloseSequenceInfo ReadMessage(MessageVersion messageVersion, Message message, MessageHeaders headers)
	{
		if (message.IsEmpty)
		{
			string message2 = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequence");
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(message2));
		}
		CloseSequenceInfo closeSequenceInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			closeSequenceInfo = CloseSequence.Create(reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		closeSequenceInfo.SetMessageId(messageVersion, headers);
		closeSequenceInfo.SetReplyTo(messageVersion, headers);
		return closeSequenceInfo;
	}
}
