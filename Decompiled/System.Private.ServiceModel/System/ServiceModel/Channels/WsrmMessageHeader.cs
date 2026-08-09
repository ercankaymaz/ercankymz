using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class WsrmMessageHeader : DictionaryHeader, IMessageHeaderWithSharedNamespace
{
	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedPrefix => XD.WsrmFeb2005Dictionary.Prefix;

	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedNamespace => WsrmIndex.GetNamespace(ReliableMessagingVersion);

	public override XmlDictionaryString DictionaryNamespace => WsrmIndex.GetNamespace(ReliableMessagingVersion);

	public override string Namespace => WsrmIndex.GetNamespaceString(ReliableMessagingVersion);

	protected ReliableMessagingVersion ReliableMessagingVersion { get; }

	protected WsrmMessageHeader(ReliableMessagingVersion reliableMessagingVersion)
	{
		ReliableMessagingVersion = reliableMessagingVersion;
	}
}
