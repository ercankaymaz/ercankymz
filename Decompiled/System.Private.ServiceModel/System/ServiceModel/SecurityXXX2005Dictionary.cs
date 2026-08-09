using System.Xml;

namespace System.ServiceModel;

internal class SecurityXXX2005Dictionary
{
	public XmlDictionaryString EncryptedHeader;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString SignatureConfirmation;

	public XmlDictionaryString ValueAttribute;

	public XmlDictionaryString TokenTypeAttribute;

	public XmlDictionaryString ThumbprintSha1ValueType;

	public XmlDictionaryString EncryptedKeyTokenType;

	public XmlDictionaryString EncryptedKeyHashValueType;

	public XmlDictionaryString SamlTokenType;

	public XmlDictionaryString Saml20TokenType;

	public XmlDictionaryString Saml11AssertionValueType;

	public SecurityXXX2005Dictionary(ServiceModelDictionary dictionary)
	{
		EncryptedHeader = dictionary.CreateString("EncryptedHeader", 60);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-wssecurity-secext-1.1.xsd", 61);
		Prefix = dictionary.CreateString("k", 185);
		SignatureConfirmation = dictionary.CreateString("SignatureConfirmation", 186);
		ValueAttribute = dictionary.CreateString("Value", 77);
		TokenTypeAttribute = dictionary.CreateString("TokenType", 187);
		ThumbprintSha1ValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1", 188);
		EncryptedKeyTokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKey", 189);
		EncryptedKeyHashValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKeySHA1", 190);
		SamlTokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1", 191);
		Saml20TokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0", 192);
		Saml11AssertionValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLID", 193);
	}
}
