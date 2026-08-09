using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel;

public abstract class ReliableMessagingVersion
{
	public static ReliableMessagingVersion Default => ReliableSessionDefaults.ReliableMessagingVersion;

	public static ReliableMessagingVersion WSReliableMessaging11 => WSReliableMessaging11Version.Instance;

	public static ReliableMessagingVersion WSReliableMessagingFebruary2005 => WSReliableMessagingFebruary2005Version.Instance;

	internal XmlDictionaryString DictionaryNamespace { get; }

	internal string Namespace { get; }

	internal ReliableMessagingVersion(string ns, XmlDictionaryString dictionaryNs)
	{
		Namespace = ns;
		DictionaryNamespace = dictionaryNs;
	}

	internal static bool IsDefined(ReliableMessagingVersion reliableMessagingVersion)
	{
		if (reliableMessagingVersion != WSReliableMessaging11)
		{
			return reliableMessagingVersion == WSReliableMessagingFebruary2005;
		}
		return true;
	}
}
