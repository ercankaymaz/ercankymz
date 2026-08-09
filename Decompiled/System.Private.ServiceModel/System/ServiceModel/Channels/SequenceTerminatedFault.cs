using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class SequenceTerminatedFault : WsrmHeaderFault
{
	private SequenceTerminatedFault(bool isSenderFault, UniqueId sequenceID, string faultReason, string exceptionMessage)
		: base(isSenderFault, "SequenceTerminated", faultReason, exceptionMessage, sequenceID, faultsInput: true, faultsOutput: true)
	{
	}

	public SequenceTerminatedFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "SequenceTerminated", reason, detailReader, reliableMessagingVersion, faultsInput: true, faultsOutput: true)
	{
	}

	public static WsrmFault CreateCommunicationFault(UniqueId sequenceID, string faultReason, string exceptionMessage)
	{
		return new SequenceTerminatedFault(isSenderFault: false, sequenceID, faultReason, exceptionMessage);
	}

	public static WsrmFault CreateMaxRetryCountExceededFault(UniqueId sequenceId)
	{
		return CreateCommunicationFault(sequenceId, System.SR.SequenceTerminatedMaximumRetryCountExceeded, null);
	}

	public static WsrmFault CreateProtocolFault(UniqueId sequenceID, string faultReason, string exceptionMessage)
	{
		return new SequenceTerminatedFault(isSenderFault: true, sequenceID, faultReason, exceptionMessage);
	}

	public static WsrmFault CreateQuotaExceededFault(UniqueId sequenceID)
	{
		return CreateProtocolFault(sequenceID, System.SR.SequenceTerminatedQuotaExceededException, null);
	}
}
