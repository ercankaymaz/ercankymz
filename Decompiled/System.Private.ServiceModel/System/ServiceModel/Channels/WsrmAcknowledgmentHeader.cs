using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmAcknowledgmentHeader : WsrmMessageHeader
{
	private int _bufferRemaining;

	private bool _final;

	private SequenceRangeCollection _ranges;

	private UniqueId _sequenceID;

	public override XmlDictionaryString DictionaryName => XD.WsrmFeb2005Dictionary.SequenceAcknowledgement;

	public WsrmAcknowledgmentHeader(ReliableMessagingVersion reliableMessagingVersion, UniqueId sequenceID, SequenceRangeCollection ranges, bool final, int bufferRemaining)
		: base(reliableMessagingVersion)
	{
		_sequenceID = sequenceID;
		_ranges = ranges;
		_final = final;
		_bufferRemaining = bufferRemaining;
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString dictionaryNamespace = DictionaryNamespace;
		WriteAckRanges(writer, base.ReliableMessagingVersion, _sequenceID, _ranges);
		if (base.ReliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11 && _final)
		{
			writer.WriteStartElement(DXD.Wsrm11Dictionary.Final, dictionaryNamespace);
			writer.WriteEndElement();
		}
		if (_bufferRemaining != -1)
		{
			writer.WriteStartElement("netrm", wsrmFeb2005Dictionary.BufferRemaining, XD.WsrmFeb2005Dictionary.NETNamespace);
			writer.WriteValue(_bufferRemaining);
			writer.WriteEndElement();
		}
	}

	internal static void WriteAckRanges(XmlDictionaryWriter writer, ReliableMessagingVersion reliableMessagingVersion, UniqueId sequenceId, SequenceRangeCollection ranges)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		writer.WriteStartElement(wsrmFeb2005Dictionary.Identifier, namespaceUri);
		writer.WriteValue(sequenceId);
		writer.WriteEndElement();
		if (ranges.Count == 0)
		{
			if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
			{
				ranges = ranges.MergeWith(0L);
			}
			else if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
			{
				writer.WriteStartElement(DXD.Wsrm11Dictionary.None, namespaceUri);
				writer.WriteEndElement();
			}
		}
		for (int i = 0; i < ranges.Count; i++)
		{
			writer.WriteStartElement(wsrmFeb2005Dictionary.AcknowledgementRange, namespaceUri);
			writer.WriteStartAttribute(wsrmFeb2005Dictionary.Lower, null);
			writer.WriteValue(ranges[i].Lower);
			writer.WriteEndAttribute();
			writer.WriteStartAttribute(wsrmFeb2005Dictionary.Upper, null);
			writer.WriteValue(ranges[i].Upper);
			writer.WriteEndAttribute();
			writer.WriteEndElement();
		}
	}
}
