using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SecurityXXX2005Dictionary
{
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

	public XmlDictionaryString EncryptedHeader;

	public XmlDictionaryString Namespace;

	public SecurityXXX2005Dictionary(IdentityModelDictionary dictionary)
	{
		Prefix = dictionary.CreateString("k", 144);
		SignatureConfirmation = dictionary.CreateString("SignatureConfirmation", 145);
		ValueAttribute = dictionary.CreateString("Value", 146);
		TokenTypeAttribute = dictionary.CreateString("TokenType", 147);
		ThumbprintSha1ValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1", 148);
		EncryptedKeyTokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKey", 149);
		EncryptedKeyHashValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKeySHA1", 150);
		SamlTokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1", 151);
		Saml20TokenType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0", 152);
		Saml11AssertionValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLID", 153);
		EncryptedHeader = dictionary.CreateString("EncryptedHeader", 154);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-wssecurity-secext-1.1.xsd", 155);
	}

	public SecurityXXX2005Dictionary(IXmlDictionary dictionary)
	{
		Prefix = LookupDictionaryString(dictionary, "k");
		SignatureConfirmation = LookupDictionaryString(dictionary, "SignatureConfirmation");
		ValueAttribute = LookupDictionaryString(dictionary, "Value");
		TokenTypeAttribute = LookupDictionaryString(dictionary, "TokenType");
		ThumbprintSha1ValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1");
		EncryptedKeyTokenType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKey");
		EncryptedKeyHashValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKeySHA1");
		SamlTokenType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1");
		Saml20TokenType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0");
		Saml11AssertionValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLID");
		EncryptedHeader = LookupDictionaryString(dictionary, "EncryptedHeader");
		Namespace = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-wssecurity-secext-1.1.xsd");
	}

	private XmlDictionaryString LookupDictionaryString(IXmlDictionary dictionary, string value)
	{
		if (!dictionary.TryLookup(value, out XmlDictionaryString result))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.XDCannotFindValueInDictionaryString, value));
		}
		return result;
	}
}
