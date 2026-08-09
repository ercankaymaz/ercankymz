using System.Xml;

namespace System.ServiceModel.Channels;

internal sealed class WsrmUsesSequenceSTRHeader : WsrmMessageHeader
{
	public override XmlDictionaryString DictionaryName => DXD.Wsrm11Dictionary.UsesSequenceSTR;

	public override bool MustUnderstand => true;

	public WsrmUsesSequenceSTRHeader()
		: base(ReliableMessagingVersion.WSReliableMessaging11)
	{
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
	}
}
