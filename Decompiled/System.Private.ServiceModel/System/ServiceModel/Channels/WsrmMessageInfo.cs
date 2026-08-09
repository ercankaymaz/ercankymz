using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmMessageInfo
{
	[Serializable]
	private class InternalFaultException : ProtocolException
	{
		private Message faultReply;

		public Message FaultReply => faultReply;

		public InternalFaultException()
		{
		}

		public InternalFaultException(Message faultReply, string message, Exception inner)
			: base(message, inner)
		{
			this.faultReply = faultReply;
		}

		protected InternalFaultException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}

	private Exception _faultException;

	private Message _faultReply;

	public WsrmAcknowledgmentInfo AcknowledgementInfo { get; private set; }

	public WsrmAckRequestedInfo AckRequestedInfo { get; private set; }

	public string Action { get; private set; }

	public CloseSequenceInfo CloseSequenceInfo { get; private set; }

	public CloseSequenceResponseInfo CloseSequenceResponseInfo { get; private set; }

	public CreateSequenceInfo CreateSequenceInfo { get; private set; }

	public CreateSequenceResponseInfo CreateSequenceResponseInfo { get; private set; }

	public Exception FaultException
	{
		get
		{
			return _faultException;
		}
		set
		{
			if (_faultException != null)
			{
				throw Fx.AssertAndThrow("FaultException can only be set once.");
			}
			_faultException = value;
		}
	}

	public MessageFault FaultInfo => MessageFault;

	public Message FaultReply
	{
		get
		{
			return _faultReply;
		}
		set
		{
			if (_faultReply != null)
			{
				throw Fx.AssertAndThrow("FaultReply can only be set once.");
			}
			_faultReply = value;
		}
	}

	public Message Message { get; private set; }

	public MessageFault MessageFault { get; private set; }

	public Exception ParsingException { get; private set; }

	public WsrmSequencedMessageInfo SequencedMessageInfo { get; private set; }

	public TerminateSequenceInfo TerminateSequenceInfo { get; private set; }

	public TerminateSequenceResponseInfo TerminateSequenceResponseInfo { get; private set; }

	public WsrmUsesSequenceSSLInfo UsesSequenceSSLInfo { get; private set; }

	public WsrmUsesSequenceSTRInfo UsesSequenceSTRInfo { get; private set; }

	public WsrmHeaderFault WsrmHeaderFault => MessageFault as WsrmHeaderFault;

	public static Exception CreateInternalFaultException(Message faultReply, string message, Exception inner)
	{
		return new InternalFaultException(faultReply, System.SR.Format(System.SR.WsrmMessageProcessingError, message), inner);
	}

	private static Exception CreateWsrmRequiredException(MessageVersion messageVersion)
	{
		string wsrmRequiredExceptionString = System.SR.WsrmRequiredExceptionString;
		string wsrmRequiredFaultString = System.SR.WsrmRequiredFaultString;
		Message faultReply = new WsrmRequiredFault(wsrmRequiredFaultString).CreateMessage(messageVersion, ReliableMessagingVersion.WSReliableMessaging11);
		return CreateInternalFaultException(faultReply, wsrmRequiredExceptionString, new ProtocolException(wsrmRequiredExceptionString));
	}

	public static WsrmMessageInfo Get(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, IChannel channel, ISession session, Message message)
	{
		return Get(messageVersion, reliableMessagingVersion, channel, session, message, csrOnly: false);
	}

	public static WsrmMessageInfo Get(MessageVersion messageVersion, ReliableMessagingVersion reliableMessagingVersion, IChannel channel, ISession session, Message message, bool csrOnly)
	{
		WsrmMessageInfo wsrmMessageInfo = new WsrmMessageInfo();
		wsrmMessageInfo.Message = message;
		bool flag = true;
		try
		{
			flag = message.IsFault;
			MessageHeaders headers = message.Headers;
			string text = (wsrmMessageInfo.Action = headers.Action);
			bool flag2 = false;
			bool flag3 = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005;
			bool flag4 = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11;
			bool flag5 = false;
			if (text == WsrmIndex.GetCreateSequenceResponseActionString(reliableMessagingVersion))
			{
				wsrmMessageInfo.CreateSequenceResponseInfo = CreateSequenceResponseInfo.ReadMessage(messageVersion, reliableMessagingVersion, message, headers);
				ValidateMustUnderstand(messageVersion, message);
				return wsrmMessageInfo;
			}
			if (csrOnly)
			{
				return wsrmMessageInfo;
			}
			if (text == WsrmIndex.GetTerminateSequenceActionString(reliableMessagingVersion))
			{
				wsrmMessageInfo.TerminateSequenceInfo = TerminateSequenceInfo.ReadMessage(messageVersion, reliableMessagingVersion, message, headers);
				flag2 = true;
			}
			else if (text == WsrmIndex.GetCreateSequenceActionString(reliableMessagingVersion))
			{
				wsrmMessageInfo.CreateSequenceInfo = CreateSequenceInfo.ReadMessage(messageVersion, reliableMessagingVersion, session as ISecureConversationSession, message, headers);
				if (flag3)
				{
					ValidateMustUnderstand(messageVersion, message);
					return wsrmMessageInfo;
				}
				flag5 = true;
			}
			else if (flag4)
			{
				if (text == "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequence")
				{
					wsrmMessageInfo.CloseSequenceInfo = CloseSequenceInfo.ReadMessage(messageVersion, message, headers);
					flag2 = true;
				}
				else if (text == "http://docs.oasis-open.org/ws-rx/wsrm/200702/CloseSequenceResponse")
				{
					wsrmMessageInfo.CloseSequenceResponseInfo = CloseSequenceResponseInfo.ReadMessage(messageVersion, message, headers);
					flag2 = true;
				}
				else if (text == WsrmIndex.GetTerminateSequenceResponseActionString(reliableMessagingVersion))
				{
					wsrmMessageInfo.TerminateSequenceResponseInfo = TerminateSequenceResponseInfo.ReadMessage(messageVersion, message, headers);
					flag2 = true;
				}
			}
			string namespaceString = WsrmIndex.GetNamespaceString(reliableMessagingVersion);
			bool flag6 = messageVersion.Envelope == EnvelopeVersion.Soap11;
			bool flag7 = false;
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			int num9 = -1;
			for (int i = 0; i < headers.Count; i++)
			{
				MessageHeaderInfo messageHeaderInfo = headers[i];
				if (!messageVersion.Envelope.IsUltimateDestinationActor(messageHeaderInfo.Actor) || !(messageHeaderInfo.Namespace == namespaceString))
				{
					continue;
				}
				bool flag8 = true;
				if (flag5)
				{
					if (flag4 && messageHeaderInfo.Name == "UsesSequenceSSL")
					{
						if (num8 != -1)
						{
							num = i;
							break;
						}
						num8 = i;
					}
					else if (flag4 && messageHeaderInfo.Name == "UsesSequenceSTR")
					{
						if (num9 != -1)
						{
							num = i;
							break;
						}
						num9 = i;
					}
					else
					{
						flag8 = false;
					}
				}
				else if (messageHeaderInfo.Name == "Sequence")
				{
					if (num2 != -1)
					{
						num = i;
						break;
					}
					num2 = i;
				}
				else if (messageHeaderInfo.Name == "SequenceAcknowledgement")
				{
					if (num3 != -1)
					{
						num = i;
						break;
					}
					num3 = i;
				}
				else if (messageHeaderInfo.Name == "AckRequested")
				{
					if (num4 != -1)
					{
						num = i;
						break;
					}
					num4 = i;
				}
				else if (flag6 && messageHeaderInfo.Name == "SequenceFault")
				{
					if (num7 != -1)
					{
						num = i;
						break;
					}
					num7 = i;
				}
				else
				{
					flag8 = false;
				}
				if (flag8)
				{
					if (i > num5)
					{
						num5 = i;
					}
					if (num6 == -1)
					{
						num6 = i;
					}
				}
			}
			if (num != -1)
			{
				Collection<MessageHeaderInfo> collection = new Collection<MessageHeaderInfo>();
				collection.Add(headers[num]);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MustUnderstandSoapException(collection, messageVersion.Envelope));
			}
			if (num5 > -1 && message is BufferedMessage bufferedMessage && bufferedMessage.Headers.ContainsOnlyBufferedMessageHeaders)
			{
				flag7 = true;
				using XmlDictionaryReader xmlDictionaryReader = headers.GetReaderAtHeader(num6);
				for (int j = num6; j <= num5; j++)
				{
					MessageHeaderInfo messageHeaderInfo2 = headers[j];
					if (flag5)
					{
						if (flag4 && j == num8)
						{
							wsrmMessageInfo.UsesSequenceSSLInfo = WsrmUsesSequenceSSLInfo.ReadHeader(xmlDictionaryReader, messageHeaderInfo2);
							headers.UnderstoodHeaders.Add(messageHeaderInfo2);
						}
						else if (flag4 && j == num9)
						{
							wsrmMessageInfo.UsesSequenceSTRInfo = WsrmUsesSequenceSTRInfo.ReadHeader(xmlDictionaryReader, messageHeaderInfo2);
							headers.UnderstoodHeaders.Add(messageHeaderInfo2);
						}
						else
						{
							xmlDictionaryReader.Skip();
						}
					}
					else if (j == num2)
					{
						wsrmMessageInfo.SequencedMessageInfo = WsrmSequencedMessageInfo.ReadHeader(reliableMessagingVersion, xmlDictionaryReader, messageHeaderInfo2);
						headers.UnderstoodHeaders.Add(messageHeaderInfo2);
					}
					else if (j == num3)
					{
						wsrmMessageInfo.AcknowledgementInfo = WsrmAcknowledgmentInfo.ReadHeader(reliableMessagingVersion, xmlDictionaryReader, messageHeaderInfo2);
						headers.UnderstoodHeaders.Add(messageHeaderInfo2);
					}
					else if (j == num4)
					{
						wsrmMessageInfo.AckRequestedInfo = WsrmAckRequestedInfo.ReadHeader(reliableMessagingVersion, xmlDictionaryReader, messageHeaderInfo2);
						headers.UnderstoodHeaders.Add(messageHeaderInfo2);
					}
					else
					{
						xmlDictionaryReader.Skip();
					}
				}
			}
			if (num5 > -1 && !flag7)
			{
				flag7 = true;
				if (flag5)
				{
					if (num8 != -1)
					{
						using XmlDictionaryReader reader = headers.GetReaderAtHeader(num8);
						MessageHeaderInfo messageHeaderInfo3 = headers[num8];
						wsrmMessageInfo.UsesSequenceSSLInfo = WsrmUsesSequenceSSLInfo.ReadHeader(reader, messageHeaderInfo3);
						headers.UnderstoodHeaders.Add(messageHeaderInfo3);
					}
					if (num9 != -1)
					{
						using XmlDictionaryReader reader2 = headers.GetReaderAtHeader(num9);
						MessageHeaderInfo messageHeaderInfo4 = headers[num9];
						wsrmMessageInfo.UsesSequenceSTRInfo = WsrmUsesSequenceSTRInfo.ReadHeader(reader2, messageHeaderInfo4);
						headers.UnderstoodHeaders.Add(messageHeaderInfo4);
					}
				}
				else
				{
					if (num2 != -1)
					{
						using XmlDictionaryReader reader3 = headers.GetReaderAtHeader(num2);
						MessageHeaderInfo messageHeaderInfo5 = headers[num2];
						wsrmMessageInfo.SequencedMessageInfo = WsrmSequencedMessageInfo.ReadHeader(reliableMessagingVersion, reader3, messageHeaderInfo5);
						headers.UnderstoodHeaders.Add(messageHeaderInfo5);
					}
					if (num3 != -1)
					{
						using XmlDictionaryReader reader4 = headers.GetReaderAtHeader(num3);
						MessageHeaderInfo messageHeaderInfo6 = headers[num3];
						wsrmMessageInfo.AcknowledgementInfo = WsrmAcknowledgmentInfo.ReadHeader(reliableMessagingVersion, reader4, messageHeaderInfo6);
						headers.UnderstoodHeaders.Add(messageHeaderInfo6);
					}
					if (num4 != -1)
					{
						using XmlDictionaryReader reader5 = headers.GetReaderAtHeader(num4);
						MessageHeaderInfo messageHeaderInfo7 = headers[num4];
						wsrmMessageInfo.AckRequestedInfo = WsrmAckRequestedInfo.ReadHeader(reliableMessagingVersion, reader5, messageHeaderInfo7);
						headers.UnderstoodHeaders.Add(messageHeaderInfo7);
					}
				}
			}
			if (flag5)
			{
				CreateSequenceInfo.ValidateCreateSequenceHeaders(messageVersion, session as ISecureConversationSession, wsrmMessageInfo);
				ValidateMustUnderstand(messageVersion, message);
				return wsrmMessageInfo;
			}
			if (wsrmMessageInfo.SequencedMessageInfo == null && wsrmMessageInfo.Action == null)
			{
				if (flag3)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageHeaderException(System.SR.NoActionNoSequenceHeaderReason, messageVersion.Addressing.Namespace, "Action", isDuplicate: false));
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateWsrmRequiredException(messageVersion));
			}
			if (wsrmMessageInfo.SequencedMessageInfo == null && message.IsFault)
			{
				wsrmMessageInfo.MessageFault = MessageFault.CreateFault(message, 65536);
				WsrmHeaderFault wsrmFault;
				if (flag6)
				{
					if (WsrmHeaderFault.TryCreateFault11(reliableMessagingVersion, message, wsrmMessageInfo.MessageFault, num7, out wsrmFault))
					{
						wsrmMessageInfo.MessageFault = wsrmFault;
						wsrmMessageInfo._faultException = WsrmFault.CreateException(wsrmFault);
					}
				}
				else if (WsrmHeaderFault.TryCreateFault12(reliableMessagingVersion, message, wsrmMessageInfo.MessageFault, out wsrmFault))
				{
					wsrmMessageInfo.MessageFault = wsrmFault;
					wsrmMessageInfo._faultException = WsrmFault.CreateException(wsrmFault);
				}
				if (wsrmFault == null)
				{
					FaultConverter faultConverter = channel.GetProperty<FaultConverter>();
					if (faultConverter == null)
					{
						faultConverter = FaultConverter.GetDefaultFaultConverter(messageVersion);
					}
					if (!faultConverter.TryCreateException(message, wsrmMessageInfo.MessageFault, out wsrmMessageInfo._faultException))
					{
						wsrmMessageInfo._faultException = new ProtocolException(System.SR.Format(System.SR.UnrecognizedFaultReceived, wsrmMessageInfo.MessageFault.Code.Namespace, wsrmMessageInfo.MessageFault.Code.Name, System.ServiceModel.FaultException.GetSafeReasonText(wsrmMessageInfo.MessageFault)));
					}
				}
				flag2 = true;
			}
			if (!flag7 && !flag2)
			{
				if (flag3)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ActionNotSupportedException(System.SR.Format(System.SR.NonWsrmFeb2005ActionNotSupported, text)));
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateWsrmRequiredException(messageVersion));
			}
			if (flag2 || WsrmUtilities.IsWsrmAction(reliableMessagingVersion, text))
			{
				ValidateMustUnderstand(messageVersion, message);
			}
		}
		catch (InternalFaultException ex)
		{
			if (DiagnosticUtility.ShouldTraceInformation)
			{
				DiagnosticUtility.TraceHandledException(ex, TraceEventType.Information);
			}
			wsrmMessageInfo.FaultReply = ex.FaultReply;
			wsrmMessageInfo._faultException = ex.InnerException;
		}
		catch (CommunicationException ex2)
		{
			if (DiagnosticUtility.ShouldTraceInformation)
			{
				DiagnosticUtility.TraceHandledException(ex2, TraceEventType.Information);
			}
			if (flag)
			{
				wsrmMessageInfo.ParsingException = ex2;
				return wsrmMessageInfo;
			}
			FaultConverter faultConverter2 = channel.GetProperty<FaultConverter>();
			if (faultConverter2 == null)
			{
				faultConverter2 = FaultConverter.GetDefaultFaultConverter(messageVersion);
			}
			if (faultConverter2.TryCreateFaultMessage(ex2, out wsrmMessageInfo._faultReply))
			{
				wsrmMessageInfo._faultException = new ProtocolException(System.SR.MessageExceptionOccurred, ex2);
			}
			else
			{
				wsrmMessageInfo.ParsingException = new ProtocolException(System.SR.MessageExceptionOccurred, ex2);
			}
		}
		catch (XmlException ex3)
		{
			if (DiagnosticUtility.ShouldTraceInformation)
			{
				DiagnosticUtility.TraceHandledException(ex3, TraceEventType.Information);
			}
			wsrmMessageInfo.ParsingException = new ProtocolException(System.SR.MessageExceptionOccurred, ex3);
		}
		return wsrmMessageInfo;
	}

	private static void ValidateMustUnderstand(MessageVersion version, Message message)
	{
		Collection<MessageHeaderInfo> headersNotUnderstood = message.Headers.GetHeadersNotUnderstood();
		if (headersNotUnderstood != null && headersNotUnderstood.Count > 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MustUnderstandSoapException(headersNotUnderstood, version.Envelope));
		}
	}
}
