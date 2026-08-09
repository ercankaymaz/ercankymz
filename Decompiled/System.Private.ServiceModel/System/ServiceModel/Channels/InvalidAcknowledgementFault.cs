using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class InvalidAcknowledgementFault : WsrmHeaderFault
{
	private readonly SequenceRangeCollection _ranges;

	public InvalidAcknowledgementFault(UniqueId sequenceID, SequenceRangeCollection ranges)
		: base(isSenderFault: true, "InvalidAcknowledgement", System.SR.InvalidAcknowledgementFaultReason, System.SR.InvalidAcknowledgementReceived, sequenceID, faultsInput: true, faultsOutput: false)
	{
		_ranges = ranges;
	}

	public InvalidAcknowledgementFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "InvalidAcknowledgement", reason, faultsInput: true, faultsOutput: false)
	{
		WsrmAcknowledgmentInfo.ReadAck(reliableMessagingVersion, detailReader, out var sequenceId, out _ranges, out var _);
		base.SequenceID = sequenceId;
		while (detailReader.IsStartElement())
		{
			detailReader.Skip();
		}
		detailReader.ReadEndElement();
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		WsrmFeb2005Dictionary wsrmFeb2005Dictionary = XD.WsrmFeb2005Dictionary;
		ReliableMessagingVersion reliableMessagingVersion = GetReliableMessagingVersion();
		XmlDictionaryString namespaceUri = WsrmIndex.GetNamespace(reliableMessagingVersion);
		writer.WriteStartElement(wsrmFeb2005Dictionary.SequenceAcknowledgement, namespaceUri);
		WsrmAcknowledgmentHeader.WriteAckRanges(writer, reliableMessagingVersion, base.SequenceID, _ranges);
		writer.WriteEndElement();
	}
}
