using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmAcknowledgmentInfo : WsrmHeaderInfo
{
	public int BufferRemaining { get; }

	public bool Final { get; }

	public SequenceRangeCollection Ranges { get; }

	public UniqueId SequenceID { get; }

	private WsrmAcknowledgmentInfo(UniqueId sequenceID, SequenceRangeCollection ranges, bool final, int bufferRemaining, MessageHeaderInfo header)
		: base(header)
	{
		SequenceID = sequenceID;
		Ranges = ranges;
		Final = final;
		BufferRemaining = bufferRemaining;
	}

	internal static void ReadAck(ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader, out UniqueId sequenceId, out SequenceRangeCollection rangeCollection, out bool final)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		reader.ReadStartElement(wsrmFeb2005Dictionary.SequenceAcknowledgement, namespaceUri);
		reader.ReadStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		sequenceId = reader.ReadContentAsUniqueId();
		reader.ReadEndElement();
		bool allowZero = reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005;
		rangeCollection = SequenceRangeCollection.Empty;
		while (reader.IsStartElement(wsrmFeb2005Dictionary.AcknowledgementRange, namespaceUri))
		{
			reader.MoveToAttribute("Lower");
			long num = WsrmUtilities.ReadSequenceNumber(reader, allowZero);
			reader.MoveToAttribute("Upper");
			long num2 = WsrmUtilities.ReadSequenceNumber(reader, allowZero);
			if (num < 0 || num > num2 || (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005 && num == 0L && num2 > 0) || (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && num == 0L))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidSequenceRange, num, num2)));
			}
			rangeCollection = rangeCollection.MergeWith(new SequenceRange(num, num2));
			reader.MoveToElement();
			WsrmUtilities.ReadEmptyElement(reader);
		}
		bool flag = rangeCollection.Count > 0;
		final = false;
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
			if (reader.IsStartElement(wsrm11Dictionary.None, namespaceUri))
			{
				if (flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, wsrmFeb2005Dictionary.SequenceAcknowledgement)));
				}
				WsrmUtilities.ReadEmptyElement(reader);
				flag = true;
			}
			if (reader.IsStartElement(wsrm11Dictionary.Final, namespaceUri))
			{
				if (!flag)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, wsrmFeb2005Dictionary.SequenceAcknowledgement)));
				}
				WsrmUtilities.ReadEmptyElement(reader);
				final = true;
			}
		}
		bool flag2 = false;
		while (reader.IsStartElement(wsrmFeb2005Dictionary.Nack, namespaceUri))
		{
			if (flag)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, "Body")));
			}
			reader.ReadStartElement();
			WsrmUtilities.ReadSequenceNumber(reader, allowZero: true);
			reader.ReadEndElement();
			flag2 = true;
		}
		if (!flag && !flag2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, "Body")));
		}
	}

	public static WsrmAcknowledgmentInfo ReadHeader(ReliableMessagingVersion reliableMessagingVersion, XmlDictionaryReader reader, MessageHeaderInfo header)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		ReadAck(reliableMessagingVersion, reader, out var sequenceId, out var rangeCollection, out var final);
		int num = -1;
		while (reader.IsStartElement())
		{
			if (reader.IsStartElement(wsrmFeb2005Dictionary.BufferRemaining, XD.WsrmFeb2005Dictionary.NETNamespace))
			{
				if (num != -1)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, "Body")));
				}
				reader.ReadStartElement();
				num = reader.ReadContentAsInt();
				reader.ReadEndElement();
				if (num < 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidBufferRemaining, num)));
				}
				continue;
			}
			if (reader.IsStartElement(wsrmFeb2005Dictionary.AcknowledgementRange, namespaceUri))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, "Body")));
			}
			if (reader.IsStartElement(wsrmFeb2005Dictionary.Nack, namespaceUri))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, "Body")));
			}
			if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
			{
				Wsrm11Dictionary wsrm11Dictionary = DXD.Wsrm11Dictionary;
				if (reader.IsStartElement(wsrm11Dictionary.None, namespaceUri) || reader.IsStartElement(wsrm11Dictionary.Final, namespaceUri))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedXmlChildNode, reader.Name, reader.NodeType, wsrmFeb2005Dictionary.SequenceAcknowledgement)));
				}
			}
			reader.Skip();
		}
		reader.ReadEndElement();
		return new WsrmAcknowledgmentInfo(sequenceId, rangeCollection, final, num, header);
	}
}
