using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class UnknownSequenceFault : WsrmHeaderFault
{
	public UnknownSequenceFault(UniqueId sequenceID)
		: base(isSenderFault: true, "UnknownSequence", System.SR.UnknownSequenceFaultReason, System.SR.UnknownSequenceMessageReceived, sequenceID, faultsInput: true, faultsOutput: true)
	{
	}

	public UnknownSequenceFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "UnknownSequence", reason, detailReader, reliableMessagingVersion, faultsInput: true, faultsOutput: true)
	{
	}

	public override CommunicationException CreateException()
	{
		string safeReasonText;
		if (base.IsRemote)
		{
			safeReasonText = FaultException.GetSafeReasonText(Reason);
			safeReasonText = System.SR.Format(System.SR.UnknownSequenceFaultReceived, safeReasonText);
		}
		else
		{
			safeReasonText = GetExceptionMessage();
		}
		return new CommunicationException(safeReasonText);
	}
}
