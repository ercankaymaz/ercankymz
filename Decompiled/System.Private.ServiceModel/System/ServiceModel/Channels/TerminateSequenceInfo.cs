using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class TerminateSequenceInfo : WsrmRequestInfo
{
	public UniqueId Identifier { get; set; }

	public long LastMsgNumber { get; set; }

	public override string RequestName => "TerminateSequence";

	public static TerminateSequenceInfo ReadMessage(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, Message message, MessageHeaders headers)
	{
		if (message.IsEmpty)
		{
			string message2 = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, WsrmIndex.GetTerminateSequenceActionString(reliableMessagingVersion));
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(message2));
		}
		TerminateSequenceInfo terminateSequenceInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			terminateSequenceInfo = TerminateSequence.Create(reliableMessagingVersion, reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			terminateSequenceInfo.SetMessageId(messageVersion, headers);
			terminateSequenceInfo.SetReplyTo(messageVersion, headers);
		}
		return terminateSequenceInfo;
	}
}
