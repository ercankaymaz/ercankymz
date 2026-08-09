using System.Xml;

namespace System.ServiceModel;

internal class SecureConversationDictionary
{
	public XmlDictionaryString Namespace;

	public XmlDictionaryString DerivedKeyToken;

	public XmlDictionaryString Nonce;

	public XmlDictionaryString Length;

	public XmlDictionaryString SecurityContextToken;

	public XmlDictionaryString AlgorithmAttribute;

	public XmlDictionaryString Generation;

	public XmlDictionaryString Label;

	public XmlDictionaryString Offset;

	public XmlDictionaryString Properties;

	public XmlDictionaryString Identifier;

	public XmlDictionaryString Cookie;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString DerivedKeyTokenType;

	public XmlDictionaryString SecurityContextTokenType;

	public XmlDictionaryString SecurityContextTokenReferenceValueType;

	public XmlDictionaryString RequestSecurityContextIssuance;

	public XmlDictionaryString RequestSecurityContextIssuanceResponse;

	public XmlDictionaryString RenewNeededFaultCode;

	public XmlDictionaryString BadContextTokenFaultCode;

	public SecureConversationDictionary()
	{
	}

	public SecureConversationDictionary(ServiceModelDictionary dictionary)
	{
	}
}
