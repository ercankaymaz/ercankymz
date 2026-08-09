using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CreateSequenceInfo : WsrmRequestInfo
{
	public EndpointAddress AcksTo { get; set; } = EndpointAddress.AnonymousAddress;

	public TimeSpan? Expires { get; set; }

	public TimeSpan? OfferExpires { get; set; }

	public UniqueId OfferIdentifier { get; set; }

	public override string RequestName => "CreateSequence";

	public Uri To { get; private set; }

	public static CreateSequenceInfo ReadMessage(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, ISecureConversationSession securitySession, Message message, MessageHeaders headers)
	{
		if (message.IsEmpty)
		{
			string text = System.SR.Format(System.SR.NonEmptyWsrmMessageIsEmpty, WsrmIndex.GetCreateSequenceActionString(reliableMessagingVersion));
			Message faultReply = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, text);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply, text, new ProtocolException(text)));
		}
		CreateSequenceInfo createSequenceInfo;
		using (XmlDictionaryReader reader = message.GetReaderAtBodyContents())
		{
			createSequenceInfo = CreateSequence.Create(messageVersion, reliableMessagingVersion, securitySession, reader);
			message.ReadFromBodyContentsToEnd(reader);
		}
		createSequenceInfo.SetMessageId(messageVersion, headers);
		createSequenceInfo.SetReplyTo(messageVersion, headers);
		if (createSequenceInfo.AcksTo.Uri != createSequenceInfo.ReplyTo.Uri)
		{
			string cSRefusedAcksToMustEqualReplyTo = System.SR.CSRefusedAcksToMustEqualReplyTo;
			Message faultReply2 = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, cSRefusedAcksToMustEqualReplyTo);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply2, cSRefusedAcksToMustEqualReplyTo, new ProtocolException(cSRefusedAcksToMustEqualReplyTo)));
		}
		createSequenceInfo.To = message.Headers.To;
		if (createSequenceInfo.To == null && messageVersion.Addressing == AddressingVersion.WSAddressing10)
		{
			createSequenceInfo.To = messageVersion.Addressing.AnonymousUri;
		}
		return createSequenceInfo;
	}

	public static void ValidateCreateSequenceHeaders(MessageVersion messageVersion, ISecureConversationSession securitySession, WsrmMessageInfo info)
	{
		string text = null;
		if (info.UsesSequenceSSLInfo != null)
		{
			text = System.SR.CSRefusedSSLNotSupported;
		}
		else if (info.UsesSequenceSTRInfo != null && securitySession == null)
		{
			text = System.SR.CSRefusedSTRNoWSSecurity;
		}
		else if (info.UsesSequenceSTRInfo == null && securitySession != null)
		{
			text = System.SR.CSRefusedNoSTRWSSecurity;
		}
		if (text != null)
		{
			Message faultReply = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, ReliableMessagingVersion.WSReliableMessaging11, text);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply, text, new ProtocolException(text)));
		}
	}
}
