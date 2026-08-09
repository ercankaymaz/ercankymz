using System.Xml;

namespace System.ServiceModel;

internal static class DXD
{
	private static Wsrm11Dictionary s_wsrm11Dictionary;

	public static AtomicTransactionExternal11Dictionary AtomicTransactionExternal11Dictionary { get; private set; }

	public static CoordinationExternal11Dictionary CoordinationExternal11Dictionary { get; private set; }

	public static SecureConversationDec2005Dictionary SecureConversationDec2005Dictionary { get; private set; }

	public static SecurityAlgorithmDec2005Dictionary SecurityAlgorithmDec2005Dictionary { get; private set; }

	public static TrustDec2005Dictionary TrustDec2005Dictionary { get; private set; }

	public static Wsrm11Dictionary Wsrm11Dictionary => s_wsrm11Dictionary;

	static DXD()
	{
		XmlDictionary dictionary = new XmlDictionary(137);
		AtomicTransactionExternal11Dictionary = new AtomicTransactionExternal11Dictionary(dictionary);
		CoordinationExternal11Dictionary = new CoordinationExternal11Dictionary(dictionary);
		SecureConversationDec2005Dictionary = new SecureConversationDec2005Dictionary(dictionary);
		SecureConversationDec2005Dictionary.PopulateSecureConversationDec2005();
		SecurityAlgorithmDec2005Dictionary = new SecurityAlgorithmDec2005Dictionary(dictionary);
		SecurityAlgorithmDec2005Dictionary.PopulateSecurityAlgorithmDictionaryString();
		TrustDec2005Dictionary = new TrustDec2005Dictionary(dictionary);
		TrustDec2005Dictionary.PopulateDec2005DictionaryStrings();
		TrustDec2005Dictionary.PopulateFeb2005DictionaryString();
		s_wsrm11Dictionary = new Wsrm11Dictionary(dictionary);
	}
}
