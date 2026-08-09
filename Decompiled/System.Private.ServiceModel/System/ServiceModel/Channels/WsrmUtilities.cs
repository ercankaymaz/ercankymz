using System.Globalization;
using System.Runtime;
using System.Xml;

namespace System.ServiceModel.Channels;

internal static class WsrmUtilities
{
	public static TimeSpan CalculateKeepAliveInterval(TimeSpan inactivityTimeout, int maxRetryCount)
	{
		return Ticks.ToTimeSpan(Ticks.FromTimeSpan(inactivityTimeout) / 2 / maxRetryCount);
	}

	internal static UniqueId NextSequenceId()
	{
		return new UniqueId();
	}

	internal static void AddAcknowledgementHeader(ReliableMessagingVersion reliableMessagingVersion, Message message, UniqueId id, SequenceRangeCollection ranges, bool final)
	{
		AddAcknowledgementHeader(reliableMessagingVersion, message, id, ranges, final, -1);
	}

	internal static void AddAcknowledgementHeader(ReliableMessagingVersion reliableMessagingVersion, Message message, UniqueId id, SequenceRangeCollection ranges, bool final, int bufferRemaining)
	{
		message.Headers.Insert(0, new WsrmAcknowledgmentHeader(reliableMessagingVersion, id, ranges, final, bufferRemaining));
	}

	internal static void AddAckRequestedHeader(ReliableMessagingVersion reliableMessagingVersion, Message message, UniqueId id)
	{
		message.Headers.Insert(0, new WsrmAckRequestedHeader(reliableMessagingVersion, id));
	}

	internal static void AddSequenceHeader(ReliableMessagingVersion reliableMessagingVersion, Message message, UniqueId id, long sequenceNumber, bool isLast)
	{
		message.Headers.Insert(0, new WsrmSequencedMessageHeader(reliableMessagingVersion, id, sequenceNumber, isLast));
	}

	internal static void AssertWsrm11(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion != ReliableMessagingVersion.WSReliableMessaging11)
		{
			throw Fx.AssertAndThrow("WS-ReliableMessaging 1.1 required.");
		}
	}

	internal static Message CreateAcknowledgmentMessage(MessageVersion version, ReliableMessagingVersion reliableMessagingVersion, UniqueId id, SequenceRangeCollection ranges, bool final, int bufferRemaining)
	{
		Message message = Message.CreateMessage(version, WsrmIndex.GetSequenceAcknowledgementActionHeader(version.Addressing, reliableMessagingVersion));
		AddAcknowledgementHeader(reliableMessagingVersion, message, id, ranges, final, bufferRemaining);
		message.Properties.AllowOutputBatching = false;
		return message;
	}

	internal static Message CreateAckRequestedMessage(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, UniqueId id)
	{
		Message message = Message.CreateMessage(messageVersion, WsrmIndex.GetAckRequestedActionHeader(messageVersion.Addressing, reliableMessagingVersion));
		AddAckRequestedHeader(reliableMessagingVersion, message, id);
		message.Properties.AllowOutputBatching = false;
		return message;
	}

	internal static Message CreateCloseSequenceResponse(MessageVersion messageVersion, UniqueId messageId, UniqueId inputId)
	{
		CloseSequenceResponse body = new CloseSequenceResponse(inputId);
		Message message = Message.CreateMessage(messageVersion, WsrmIndex.GetCloseSequenceResponseActionHeader(messageVersion.Addressing), body);
		message.Headers.RelatesTo = messageId;
		return message;
	}

	internal static Message CreateCreateSequenceResponse(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, bool duplex, CreateSequenceInfo createSequenceInfo, bool ordered, UniqueId inputId, EndpointAddress acceptAcksTo)
	{
		CreateSequenceResponse createSequenceResponse = new CreateSequenceResponse(messageVersion.Addressing, reliableMessagingVersion);
		createSequenceResponse.Identifier = inputId;
		createSequenceResponse.Expires = createSequenceInfo.Expires;
		createSequenceResponse.Ordered = ordered;
		if (duplex)
		{
			createSequenceResponse.AcceptAcksTo = acceptAcksTo;
		}
		return Message.CreateMessage(messageVersion, ActionHeader.Create(WsrmIndex.GetCreateSequenceResponseAction(reliableMessagingVersion), messageVersion.Addressing), createSequenceResponse);
	}

	internal static Message CreateCSRefusedCommunicationFault(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, string reason)
	{
		return CreateCSRefusedFault(messageVersion, reliableMessagingVersion, isSenderFault: false, null, reason);
	}

	internal static Message CreateCSRefusedProtocolFault(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, string reason)
	{
		return CreateCSRefusedFault(messageVersion, reliableMessagingVersion, isSenderFault: true, null, reason);
	}

	internal static Message CreateCSRefusedServerTooBusyFault(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, string reason)
	{
		FaultCode subCode = new FaultCode("ConnectionLimitReached", "http://schemas.microsoft.com/ws/2006/05/rm");
		subCode = new FaultCode("CreateSequenceRefused", WsrmIndex.GetNamespaceString(reliableMessagingVersion), subCode);
		return CreateCSRefusedFault(messageVersion, reliableMessagingVersion, isSenderFault: false, subCode, reason);
	}

	private static Message CreateCSRefusedFault(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, bool isSenderFault, FaultCode subCode, string reason)
	{
		FaultCode code;
		if (messageVersion.Envelope == EnvelopeVersion.Soap11)
		{
			code = new FaultCode("CreateSequenceRefused", WsrmIndex.GetNamespaceString(reliableMessagingVersion));
		}
		else
		{
			if (messageVersion.Envelope != EnvelopeVersion.Soap12)
			{
				throw Fx.AssertAndThrow("Unsupported version.");
			}
			if (subCode == null)
			{
				subCode = new FaultCode("CreateSequenceRefused", WsrmIndex.GetNamespaceString(reliableMessagingVersion), subCode);
			}
			code = ((!isSenderFault) ? FaultCode.CreateReceiverFaultCode(subCode) : FaultCode.CreateSenderFaultCode(subCode));
		}
		FaultReason reason2 = new FaultReason(System.SR.Format(System.SR.CSRefused, reason), CultureInfo.CurrentCulture);
		MessageFault fault = MessageFault.CreateFault(code, reason2);
		string faultActionString = WsrmIndex.GetFaultActionString(messageVersion.Addressing, reliableMessagingVersion);
		return Message.CreateMessage(messageVersion, fault, faultActionString);
	}

	public static Exception CreateCSFaultException(MessageVersion version, ReliableMessagingVersion reliableMessagingVersion, Message message, IChannel innerChannel)
	{
		MessageFault messageFault = MessageFault.CreateFault(message, 65536);
		FaultCode code = messageFault.Code;
		FaultCode faultCode;
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			faultCode = code;
		}
		else
		{
			if (version.Envelope != EnvelopeVersion.Soap12)
			{
				throw Fx.AssertAndThrow("Unsupported version.");
			}
			faultCode = code.SubCode;
		}
		if (faultCode != null)
		{
			if (faultCode.Namespace == WsrmIndex.GetNamespaceString(reliableMessagingVersion) && faultCode.Name == "CreateSequenceRefused")
			{
				string safeReasonText = FaultException.GetSafeReasonText(messageFault);
				if (version.Envelope == EnvelopeVersion.Soap12)
				{
					FaultCode subCode = faultCode.SubCode;
					if (subCode != null && subCode.Namespace == "http://schemas.microsoft.com/ws/2006/05/rm" && subCode.Name == "ConnectionLimitReached")
					{
						return new ServerTooBusyException(safeReasonText);
					}
					if (code.IsSenderFault)
					{
						return new ProtocolException(safeReasonText);
					}
				}
				return new CommunicationException(safeReasonText);
			}
			if (faultCode.Namespace == version.Addressing.Namespace && faultCode.Name == "EndpointUnavailable")
			{
				return new EndpointNotFoundException(FaultException.GetSafeReasonText(messageFault));
			}
		}
		FaultConverter faultConverter = innerChannel.GetProperty<FaultConverter>();
		if (faultConverter == null)
		{
			faultConverter = FaultConverter.GetDefaultFaultConverter(version);
		}
		if (faultConverter.TryCreateException(message, messageFault, out var exception))
		{
			return exception;
		}
		return new ProtocolException(System.SR.Format(System.SR.UnrecognizedFaultReceivedOnOpen, messageFault.Code.Namespace, messageFault.Code.Name, FaultException.GetSafeReasonText(messageFault)));
	}

	internal static Message CreateEndpointNotFoundFault(MessageVersion version, string reason)
	{
		FaultCode faultCode = new FaultCode("EndpointUnavailable", version.Addressing.Namespace);
		FaultCode code;
		if (version.Envelope == EnvelopeVersion.Soap11)
		{
			code = faultCode;
		}
		else
		{
			if (version.Envelope != EnvelopeVersion.Soap12)
			{
				throw Fx.AssertAndThrow("Unsupported version.");
			}
			code = FaultCode.CreateSenderFaultCode(faultCode);
		}
		FaultReason reason2 = new FaultReason(reason, CultureInfo.CurrentCulture);
		MessageFault fault = MessageFault.CreateFault(code, reason2);
		return Message.CreateMessage(version, fault, version.Addressing.DefaultFaultAction);
	}

	internal static Message CreateTerminateMessage(MessageVersion version, ReliableMessagingVersion reliableMessagingVersion, UniqueId id)
	{
		return CreateTerminateMessage(version, reliableMessagingVersion, id, -1L);
	}

	internal static Message CreateTerminateMessage(MessageVersion version, ReliableMessagingVersion reliableMessagingVersion, UniqueId id, long last)
	{
		Message message = Message.CreateMessage(version, WsrmIndex.GetTerminateSequenceActionHeader(version.Addressing, reliableMessagingVersion), new TerminateSequence(reliableMessagingVersion, id, last));
		message.Properties.AllowOutputBatching = false;
		return message;
	}

	internal static Message CreateTerminateResponseMessage(MessageVersion version, UniqueId messageId, UniqueId sequenceId)
	{
		Message message = Message.CreateMessage(version, WsrmIndex.GetTerminateSequenceResponseActionHeader(version.Addressing), new TerminateSequenceResponse(sequenceId));
		message.Properties.AllowOutputBatching = false;
		message.Headers.RelatesTo = messageId;
		return message;
	}

	internal static UniqueId GetInputId(WsrmMessageInfo info)
	{
		if (info.TerminateSequenceInfo != null)
		{
			return info.TerminateSequenceInfo.Identifier;
		}
		if (info.SequencedMessageInfo != null)
		{
			return info.SequencedMessageInfo.SequenceID;
		}
		if (info.AckRequestedInfo != null)
		{
			return info.AckRequestedInfo.SequenceID;
		}
		if (info.WsrmHeaderFault != null && info.WsrmHeaderFault.FaultsInput)
		{
			return info.WsrmHeaderFault.SequenceID;
		}
		if (info.CloseSequenceInfo != null)
		{
			return info.CloseSequenceInfo.Identifier;
		}
		return null;
	}

	internal static UniqueId GetOutputId(ReliableMessagingVersion reliableMessagingVersion, WsrmMessageInfo info)
	{
		if (info.AcknowledgementInfo != null)
		{
			return info.AcknowledgementInfo.SequenceID;
		}
		if (info.WsrmHeaderFault != null && info.WsrmHeaderFault.FaultsOutput)
		{
			return info.WsrmHeaderFault.SequenceID;
		}
		if (info.TerminateSequenceResponseInfo != null)
		{
			return info.TerminateSequenceResponseInfo.Identifier;
		}
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			if (info.CloseSequenceInfo != null)
			{
				return info.CloseSequenceInfo.Identifier;
			}
			if (info.CloseSequenceResponseInfo != null)
			{
				return info.CloseSequenceResponseInfo.Identifier;
			}
			if (info.TerminateSequenceResponseInfo != null)
			{
				return info.TerminateSequenceResponseInfo.Identifier;
			}
		}
		return null;
	}

	internal static bool IsWsrmAction(ReliableMessagingVersion reliableMessagingVersion, string action)
	{
		return action?.StartsWith(WsrmIndex.GetNamespaceString(reliableMessagingVersion), StringComparison.Ordinal) ?? false;
	}

	public static void ReadEmptyElement(XmlDictionaryReader reader)
	{
		if (reader.IsEmptyElement)
		{
			reader.Read();
			return;
		}
		reader.Read();
		reader.ReadEndElement();
	}

	public static UniqueId ReadIdentifier(XmlDictionaryReader reader, ReliableMessagingVersion reliableMessagingVersion)
	{
		reader.ReadStartElement(XD.WsrmFeb2005Dictionary.Identifier, WsrmIndex.GetNamespace(reliableMessagingVersion));
		UniqueId result = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		return result;
	}

	public static long ReadSequenceNumber(XmlDictionaryReader reader)
	{
		return ReadSequenceNumber(reader, allowZero: false);
	}

	public static long ReadSequenceNumber(XmlDictionaryReader reader, bool allowZero)
	{
		long num = reader.ReadContentAsLong();
		if (num < 0 || (num == 0L && !allowZero))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidSequenceNumber, num)));
		}
		return num;
	}

	public static WsrmFault ValidateCloseSequenceResponse(ChannelReliableSession session, UniqueId messageId, WsrmMessageInfo info, long last)
	{
		string text = null;
		string text2 = null;
		if (info.CloseSequenceResponseInfo == null)
		{
			text = System.SR.Format(System.SR.InvalidWsrmResponseSessionFaultedExceptionString, "CloseSequence", info.Action, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
			text2 = System.SR.Format(System.SR.InvalidWsrmResponseSessionFaultedFaultString, "CloseSequence", info.Action, "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse");
		}
		else if (!object.Equals(messageId, info.CloseSequenceResponseInfo.RelatesTo))
		{
			text = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToExceptionString, "CloseSequence");
			text2 = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToFaultString, "CloseSequence");
		}
		else
		{
			if (info.AcknowledgementInfo != null && info.AcknowledgementInfo.Final)
			{
				return ValidateFinalAck(session, info, last);
			}
			text = System.SR.MissingFinalAckExceptionString;
			text2 = System.SR.SequenceTerminatedMissingFinalAck;
		}
		UniqueId outputID = session.OutputID;
		return SequenceTerminatedFault.CreateProtocolFault(outputID, text2, text);
	}

	public static WsrmFault ValidateFinalAck(ChannelReliableSession session, WsrmMessageInfo info, long last)
	{
		WsrmAcknowledgmentInfo acknowledgementInfo = info.AcknowledgementInfo;
		WsrmFault wsrmFault = ValidateFinalAckExists(session, acknowledgementInfo);
		if (wsrmFault != null)
		{
			return wsrmFault;
		}
		SequenceRangeCollection ranges = acknowledgementInfo.Ranges;
		if (last == 0L)
		{
			if (ranges.Count == 0)
			{
				return null;
			}
		}
		else if (ranges.Count == 1 && ranges[0].Lower == 1 && ranges[0].Upper == last)
		{
			return null;
		}
		return new InvalidAcknowledgementFault(session.OutputID, acknowledgementInfo.Ranges);
	}

	public static WsrmFault ValidateFinalAckExists(ChannelReliableSession session, WsrmAcknowledgmentInfo ackInfo)
	{
		if (ackInfo == null || !ackInfo.Final)
		{
			string missingFinalAckExceptionString = System.SR.MissingFinalAckExceptionString;
			string sequenceTerminatedMissingFinalAck = System.SR.SequenceTerminatedMissingFinalAck;
			return SequenceTerminatedFault.CreateProtocolFault(session.OutputID, sequenceTerminatedMissingFinalAck, missingFinalAckExceptionString);
		}
		return null;
	}

	public static WsrmFault ValidateTerminateSequenceResponse(ChannelReliableSession session, UniqueId messageId, WsrmMessageInfo info, long last)
	{
		string text = null;
		string text2 = null;
		if (info.WsrmHeaderFault is UnknownSequenceFault)
		{
			return null;
		}
		if (info.TerminateSequenceResponseInfo == null)
		{
			text = System.SR.Format(System.SR.InvalidWsrmResponseSessionFaultedExceptionString, "TerminateSequence", info.Action, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse");
			text2 = System.SR.Format(System.SR.InvalidWsrmResponseSessionFaultedFaultString, "TerminateSequence", info.Action, "http://docs.oasis-open.org/ws-rx/wsrm/200702/TerminateSequenceResponse");
		}
		else
		{
			if (object.Equals(messageId, info.TerminateSequenceResponseInfo.RelatesTo))
			{
				return ValidateFinalAck(session, info, last);
			}
			text = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToExceptionString, "TerminateSequence");
			text2 = System.SR.Format(System.SR.WsrmMessageWithWrongRelatesToFaultString, "TerminateSequence");
		}
		UniqueId outputID = session.OutputID;
		return SequenceTerminatedFault.CreateProtocolFault(outputID, text2, text);
	}

	public static bool ValidateWsrmRequest(ChannelReliableSession session, WsrmRequestInfo info, IReliableChannelBinder binder, RequestContext context)
	{
		if (!(info is CloseSequenceInfo) && !(info is TerminateSequenceInfo))
		{
			throw Fx.AssertAndThrow("Method is meant for CloseSequence or TerminateSequence only.");
		}
		if (info.ReplyTo.Uri != binder.RemoteAddress.Uri)
		{
			string faultReason = System.SR.Format(System.SR.WsrmRequestIncorrectReplyToFaultString, info.RequestName);
			string exceptionMessage = System.SR.Format(System.SR.WsrmRequestIncorrectReplyToExceptionString, info.RequestName);
			WsrmFault wsrmFault = SequenceTerminatedFault.CreateProtocolFault(session.InputID, faultReason, exceptionMessage);
			session.OnLocalFault(wsrmFault.CreateException(), wsrmFault, context);
			return false;
		}
		return true;
	}

	public static void WriteIdentifier(XmlDictionaryWriter writer, ReliableMessagingVersion reliableMessagingVersion, UniqueId sequenceId)
	{
		writer.WriteStartElement("r", XD.WsrmFeb2005Dictionary.Identifier, WsrmIndex.GetNamespace(reliableMessagingVersion));
		writer.WriteValue(sequenceId);
		writer.WriteEndElement();
	}
}
