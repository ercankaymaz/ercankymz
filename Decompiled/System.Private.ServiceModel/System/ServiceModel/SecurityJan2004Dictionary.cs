using System.Xml;

namespace System.ServiceModel;

internal class SecurityJan2004Dictionary
{
	public XmlDictionaryString SecurityTokenReference;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString Security;

	public XmlDictionaryString ValueType;

	public XmlDictionaryString TypeAttribute;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString NonceElement;

	public XmlDictionaryString PasswordElement;

	public XmlDictionaryString PasswordTextName;

	public XmlDictionaryString UserNameElement;

	public XmlDictionaryString UserNameTokenElement;

	public XmlDictionaryString BinarySecurityToken;

	public XmlDictionaryString EncodingType;

	public XmlDictionaryString Reference;

	public XmlDictionaryString URI;

	public XmlDictionaryString KeyIdentifier;

	public XmlDictionaryString EncodingTypeValueBase64Binary;

	public XmlDictionaryString EncodingTypeValueHexBinary;

	public XmlDictionaryString EncodingTypeValueText;

	public XmlDictionaryString X509SKIValueType;

	public XmlDictionaryString KerberosTokenTypeGSS;

	public XmlDictionaryString KerberosTokenType1510;

	public XmlDictionaryString SamlAssertionIdValueType;

	public XmlDictionaryString SamlAssertion;

	public XmlDictionaryString SamlUri;

	public XmlDictionaryString RelAssertionValueType;

	public XmlDictionaryString FailedAuthenticationFaultCode;

	public XmlDictionaryString InvalidSecurityTokenFaultCode;

	public XmlDictionaryString InvalidSecurityFaultCode;

	public XmlDictionaryString KerberosHashValueType;

	public SecurityJan2004Dictionary(ServiceModelDictionary dictionary)
	{
		SecurityTokenReference = dictionary.CreateString("SecurityTokenReference", 30);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", 36);
		Security = dictionary.CreateString("Security", 52);
		ValueType = dictionary.CreateString("ValueType", 58);
		TypeAttribute = dictionary.CreateString("Type", 59);
		Prefix = dictionary.CreateString("o", 164);
		NonceElement = dictionary.CreateString("Nonce", 40);
		PasswordElement = dictionary.CreateString("Password", 165);
		PasswordTextName = dictionary.CreateString("PasswordText", 166);
		UserNameElement = dictionary.CreateString("Username", 167);
		UserNameTokenElement = dictionary.CreateString("UsernameToken", 168);
		BinarySecurityToken = dictionary.CreateString("BinarySecurityToken", 169);
		EncodingType = dictionary.CreateString("EncodingType", 170);
		Reference = dictionary.CreateString("Reference", 12);
		URI = dictionary.CreateString("URI", 11);
		KeyIdentifier = dictionary.CreateString("KeyIdentifier", 171);
		EncodingTypeValueBase64Binary = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary", 172);
		EncodingTypeValueHexBinary = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary", 173);
		EncodingTypeValueText = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text", 174);
		X509SKIValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier", 175);
		KerberosTokenTypeGSS = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ", 176);
		KerberosTokenType1510 = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ1510", 177);
		SamlAssertionIdValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.0#SAMLAssertionID", 178);
		SamlAssertion = dictionary.CreateString("Assertion", 179);
		SamlUri = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:assertion", 180);
		RelAssertionValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-rel-token-profile-1.0.pdf#license", 181);
		FailedAuthenticationFaultCode = dictionary.CreateString("FailedAuthentication", 182);
		InvalidSecurityTokenFaultCode = dictionary.CreateString("InvalidSecurityToken", 183);
		InvalidSecurityFaultCode = dictionary.CreateString("InvalidSecurity", 184);
		KerberosHashValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#Kerberosv5APREQSHA1", 427);
	}
}
