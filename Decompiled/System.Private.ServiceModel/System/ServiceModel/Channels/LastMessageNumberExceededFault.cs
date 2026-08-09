using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class LastMessageNumberExceededFault : WsrmHeaderFault
{
	public LastMessageNumberExceededFault(UniqueId sequenceID)
		: base(isSenderFault: true, "LastMessageNumberExceeded", System.SR.LastMessageNumberExceededFaultReason, System.SR.LastMessageNumberExceeded, sequenceID, faultsInput: false, faultsOutput: true)
	{
	}

	public LastMessageNumberExceededFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "LastMessageNumberExceeded", reason, detailReader, reliableMessagingVersion, faultsInput: false, faultsOutput: true)
	{
	}
}
