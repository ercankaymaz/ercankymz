using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class CreateSequence : BodyWriter
{
	private AddressingVersion _addressingVersion;

	private IClientReliableChannelBinder _binder;

	private UniqueId _offerIdentifier;

	private bool _ordered;

	private ReliableMessagingVersion _reliableMessagingVersion;

	private CreateSequence()
		: base(isBuffered: true)
	{
	}

	public CreateSequence(AddressingVersion addressingVersion, ReliableMessagingVersion reliableMessagingVersion, bool ordered, IClientReliableChannelBinder binder, UniqueId offerIdentifier)
		: base(isBuffered: true)
	{
		_addressingVersion = addressingVersion;
		_reliableMessagingVersion = reliableMessagingVersion;
		_ordered = ordered;
		_binder = binder;
		_offerIdentifier = offerIdentifier;
	}

	public static CreateSequenceInfo Create(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, ISecureConversationSession securitySession, XmlDictionaryReader reader)
	{
		try
		{
			CreateSequenceInfo createSequenceInfo = new CreateSequenceInfo();
			WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
			XmlDictionaryString xmlDictionaryString = WsrmIndex.GetNamespace(reliableMessagingVersion);
			reader.ReadStartElement(wsrmFeb2005Dictionary.CreateSequence, xmlDictionaryString);
			createSequenceInfo.AcksTo = EndpointAddress.ReadFrom(messageVersion.Addressing, reader, wsrmFeb2005Dictionary.AcksTo, xmlDictionaryString);
			if (reader.IsStartElement(wsrmFeb2005Dictionary.Expires, xmlDictionaryString))
			{
				createSequenceInfo.Expires = reader.ReadElementContentAsTimeSpan();
			}
			if (reader.IsStartElement(wsrmFeb2005Dictionary.Offer, xmlDictionaryString))
			{
				reader.ReadStartElement();
				reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, xmlDictionaryString);
				createSequenceInfo.OfferIdentifier = reader.ReadContentAsUniqueId();
				reader.ReadEndElement();
				bool flag = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
				Wsrm11Dictionary wsrm11Dictionary = (flag ? DXD.Wsrm11Dictionary : null);
				if (flag)
				{
					EndpointAddress endpointAddress = EndpointAddress.ReadFrom(messageVersion.Addressing, reader, wsrm11Dictionary.Endpoint, xmlDictionaryString);
					if (endpointAddress.Uri != createSequenceInfo.AcksTo.Uri)
					{
						string cSRefusedAcksToMustEqualEndpoint = System.SR.CSRefusedAcksToMustEqualEndpoint;
						Message faultReply = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, cSRefusedAcksToMustEqualEndpoint);
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply, cSRefusedAcksToMustEqualEndpoint, new ProtocolException(cSRefusedAcksToMustEqualEndpoint)));
					}
				}
				if (reader.IsStartElement(wsrmFeb2005Dictionary.Expires, xmlDictionaryString))
				{
					createSequenceInfo.OfferExpires = reader.ReadElementContentAsTimeSpan();
				}
				if (flag && reader.IsStartElement(wsrm11Dictionary.IncompleteSequenceBehavior, xmlDictionaryString))
				{
					string text = reader.ReadElementContentAsString();
					if (text != "DiscardEntireSequence" && text != "DiscardFollowingFirstGap" && text != "NoDiscard")
					{
						string cSRefusedInvalidIncompleteSequenceBehavior = System.SR.CSRefusedInvalidIncompleteSequenceBehavior;
						Message faultReply2 = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, cSRefusedInvalidIncompleteSequenceBehavior);
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply2, cSRefusedInvalidIncompleteSequenceBehavior, new ProtocolException(cSRefusedInvalidIncompleteSequenceBehavior)));
					}
				}
				while (reader.IsStartElement())
				{
					reader.Skip();
				}
				reader.ReadEndElement();
			}
			if (securitySession != null)
			{
				bool flag2 = false;
				while (reader.IsStartElement())
				{
					if (securitySession.TryReadSessionTokenIdentifier(reader))
					{
						flag2 = true;
						break;
					}
					reader.Skip();
				}
				if (!flag2)
				{
					string cSRefusedRequiredSecurityElementMissing = System.SR.CSRefusedRequiredSecurityElementMissing;
					Message faultReply3 = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, cSRefusedRequiredSecurityElementMissing);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply3, cSRefusedRequiredSecurityElementMissing, new ProtocolException(cSRefusedRequiredSecurityElementMissing)));
				}
			}
			while (reader.IsStartElement())
			{
				reader.Skip();
			}
			reader.ReadEndElement();
			if (reader.IsStartElement())
			{
				string cSRefusedUnexpectedElementAtEndOfCSMessage = System.SR.CSRefusedUnexpectedElementAtEndOfCSMessage;
				Message faultReply4 = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, cSRefusedUnexpectedElementAtEndOfCSMessage);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply4, cSRefusedUnexpectedElementAtEndOfCSMessage, new ProtocolException(cSRefusedUnexpectedElementAtEndOfCSMessage)));
			}
			return createSequenceInfo;
		}
		catch (XmlException innerException)
		{
			string text2 = System.SR.Format(System.SR.CouldNotParseWithAction, WsrmIndex.GetCreateSequenceActionString(reliableMessagingVersion));
			Message faultReply5 = WsrmUtilities.CreateCSRefusedProtocolFault(messageVersion, reliableMessagingVersion, text2);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(WsrmMessageInfo.CreateInternalFaultException(faultReply5, text2, new ProtocolException(text2, innerException)));
		}
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString xmlDictionaryString = WsrmIndex.GetNamespace(_reliableMessagingVersion);
		writer.WriteStartElement(wsrmFeb2005Dictionary.CreateSequence, xmlDictionaryString);
		EndpointAddress localAddress = _binder.LocalAddress;
		localAddress.WriteTo(_addressingVersion, writer, wsrmFeb2005Dictionary.AcksTo, xmlDictionaryString);
		if (_offerIdentifier != null)
		{
			writer.WriteStartElement(wsrmFeb2005Dictionary.Offer, xmlDictionaryString);
			writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, xmlDictionaryString);
			writer.WriteValue(_offerIdentifier);
			writer.WriteEndElement();
			if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
			{
				Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
				localAddress.WriteTo(_addressingVersion, writer, wsrm11Dictionary.Endpoint, xmlDictionaryString);
				writer.WriteStartElement(wsrm11Dictionary.IncompleteSequenceBehavior, xmlDictionaryString);
				writer.WriteValue(_ordered ? wsrm11Dictionary.DiscardFollowingFirstGap : wsrm11Dictionary.NoDiscard);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		if (_binder.GetInnerSession() is ISecureConversationSession secureConversationSession)
		{
			secureConversationSession.WriteSessionTokenIdentifier(writer);
		}
		writer.WriteEndElement();
	}
}
