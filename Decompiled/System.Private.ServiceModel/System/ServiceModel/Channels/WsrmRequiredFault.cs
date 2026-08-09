using System.Xml;

namespace System.ServiceModel.Channels;

internal class WsrmRequiredFault : WsrmFault
{
	public WsrmRequiredFault(string faultReason)
		: base(isSenderFault: true, "WsrmRequired", faultReason, null)
	{
	}

	protected override FaultCode Get11Code(FaultCode code, string subcode)
	{
		return new FaultCode(subcode, WsrmIndex.GetNamespaceString(GetReliableMessagingVersion()));
	}

	protected override bool Get12HasDetail()
	{
		return false;
	}

	protected override void OnFaultMessageCreated(MessageVersion version, Message message)
	{
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
	}
}
