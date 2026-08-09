using System.Xml;

namespace System.ServiceModel.Security;

public abstract class SecureConversationVersion
{
	internal class WSSecureConversationVersionFeb2005 : SecureConversationVersion
	{
		private static readonly WSSecureConversationVersionFeb2005 s_instance = new WSSecureConversationVersionFeb2005();

		public static SecureConversationVersion Instance => s_instance;

		protected WSSecureConversationVersionFeb2005()
			: base(XD.SecureConversationFeb2005Dictionary.Namespace, XD.SecureConversationFeb2005Dictionary.Prefix)
		{
		}
	}

	internal class WSSecureConversationVersion13 : SecureConversationVersion
	{
		private static readonly WSSecureConversationVersion13 s_instance = new WSSecureConversationVersion13();

		public static SecureConversationVersion Instance => s_instance;

		protected WSSecureConversationVersion13()
			: base(DXD.SecureConversationDec2005Dictionary.Namespace, DXD.SecureConversationDec2005Dictionary.Prefix)
		{
		}
	}

	private readonly XmlDictionaryString _prefix;

	public XmlDictionaryString Namespace { get; }

	public XmlDictionaryString Prefix => _prefix;

	public static SecureConversationVersion Default => WSSecureConversationFeb2005;

	public static SecureConversationVersion WSSecureConversationFeb2005 => WSSecureConversationVersionFeb2005.Instance;

	public static SecureConversationVersion WSSecureConversation13 => WSSecureConversationVersion13.Instance;

	internal SecureConversationVersion(XmlDictionaryString ns, XmlDictionaryString prefix)
	{
		Namespace = ns;
		_prefix = prefix;
	}
}
