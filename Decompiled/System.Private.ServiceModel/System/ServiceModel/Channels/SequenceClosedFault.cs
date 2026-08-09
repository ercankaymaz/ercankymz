using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class SequenceClosedFault : WsrmHeaderFault
{
	public SequenceClosedFault(UniqueId sequenceID)
		: base(isSenderFault: true, "SequenceClosed", System.SR.SequenceClosedFaultString, null, sequenceID, faultsInput: false, faultsOutput: true)
	{
	}

	public SequenceClosedFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "SequenceClosed", reason, detailReader, reliableMessagingVersion, faultsInput: false, faultsOutput: true)
	{
	}
}
