using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class MessageNumberRolloverFault : WsrmHeaderFault
{
	public MessageNumberRolloverFault(UniqueId sequenceID)
		: base(isSenderFault: true, "MessageNumberRollover", System.SR.MessageNumberRolloverFaultReason, System.SR.MessageNumberRollover, sequenceID, faultsInput: true, faultsOutput: true)
	{
	}

	public MessageNumberRolloverFault(FaultCode code, FaultReason reason, XmlDictionaryReader detailReader, ReliableMessagingVersion reliableMessagingVersion)
		: base(code, "MessageNumberRollover", reason, faultsInput: true, faultsOutput: true)
	{
		try
		{
			base.SequenceID = WsrmUtilities.ReadIdentifier(detailReader, reliableMessagingVersion);
			if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
			{
				detailReader.ReadStartElement(DXD.Wsrm11Dictionary.MaxMessageNumber, WsrmIndex.GetNamespace(reliableMessagingVersion));
				string s = detailReader.ReadContentAsString();
				if (!ulong.TryParse(s, out var result) || result == 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.InvalidSequenceNumber, result)));
				}
				detailReader.ReadEndElement();
			}
		}
		finally
		{
			detailReader.Close();
		}
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		ReliableMessagingVersion reliableMessagingVersion = GetReliableMessagingVersion();
		WsrmUtilities.WriteIdentifier(writer, reliableMessagingVersion, base.SequenceID);
		if (reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessaging11)
		{
			writer.WriteStartElement("r", DXD.Wsrm11Dictionary.MaxMessageNumber, WsrmIndex.GetNamespace(reliableMessagingVersion));
			writer.WriteValue(long.MaxValue);
			writer.WriteEndElement();
		}
	}
}
