using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SecurityJan2004Dictionary
{
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

	public XmlDictionaryString SecurityTokenReference;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString Security;

	public XmlDictionaryString ValueType;

	public XmlDictionaryString TypeAttribute;

	public XmlDictionaryString KerberosHashValueType;

	public SecurityJan2004Dictionary(IdentityModelDictionary dictionary)
	{
		Prefix = dictionary.CreateString("o", 119);
		NonceElement = dictionary.CreateString("Nonce", 120);
		PasswordElement = dictionary.CreateString("Password", 121);
		PasswordTextName = dictionary.CreateString("PasswordText", 122);
		UserNameElement = dictionary.CreateString("Username", 123);
		UserNameTokenElement = dictionary.CreateString("UsernameToken", 124);
		BinarySecurityToken = dictionary.CreateString("BinarySecurityToken", 125);
		EncodingType = dictionary.CreateString("EncodingType", 126);
		Reference = dictionary.CreateString("Reference", 2);
		URI = dictionary.CreateString("URI", 1);
		KeyIdentifier = dictionary.CreateString("KeyIdentifier", 127);
		EncodingTypeValueBase64Binary = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary", 128);
		EncodingTypeValueHexBinary = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary", 129);
		EncodingTypeValueText = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text", 130);
		X509SKIValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier", 131);
		KerberosTokenTypeGSS = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ", 132);
		KerberosTokenType1510 = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ1510", 133);
		SamlAssertionIdValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.0#SAMLAssertionID", 134);
		SamlAssertion = dictionary.CreateString("Assertion", 28);
		SamlUri = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:assertion", 55);
		RelAssertionValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-rel-token-profile-1.0.pdf#license", 135);
		FailedAuthenticationFaultCode = dictionary.CreateString("FailedAuthentication", 136);
		InvalidSecurityTokenFaultCode = dictionary.CreateString("InvalidSecurityToken", 137);
		InvalidSecurityFaultCode = dictionary.CreateString("InvalidSecurity", 138);
		SecurityTokenReference = dictionary.CreateString("SecurityTokenReference", 139);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", 140);
		Security = dictionary.CreateString("Security", 141);
		ValueType = dictionary.CreateString("ValueType", 142);
		TypeAttribute = dictionary.CreateString("Type", 83);
		KerberosHashValueType = dictionary.CreateString("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#Kerberosv5APREQSHA1", 143);
	}

	public SecurityJan2004Dictionary(IXmlDictionary dictionary)
	{
		Prefix = LookupDictionaryString(dictionary, "o");
		NonceElement = LookupDictionaryString(dictionary, "Nonce");
		PasswordElement = LookupDictionaryString(dictionary, "Password");
		PasswordTextName = LookupDictionaryString(dictionary, "PasswordText");
		UserNameElement = LookupDictionaryString(dictionary, "Username");
		UserNameTokenElement = LookupDictionaryString(dictionary, "UsernameToken");
		BinarySecurityToken = LookupDictionaryString(dictionary, "BinarySecurityToken");
		EncodingType = LookupDictionaryString(dictionary, "EncodingType");
		Reference = LookupDictionaryString(dictionary, "Reference");
		URI = LookupDictionaryString(dictionary, "URI");
		KeyIdentifier = LookupDictionaryString(dictionary, "KeyIdentifier");
		EncodingTypeValueBase64Binary = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
		EncodingTypeValueHexBinary = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#HexBinary");
		EncodingTypeValueText = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Text");
		X509SKIValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier");
		KerberosTokenTypeGSS = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ");
		KerberosTokenType1510 = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ1510");
		SamlAssertionIdValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.0#SAMLAssertionID");
		SamlAssertion = LookupDictionaryString(dictionary, "Assertion");
		SamlUri = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.0:assertion");
		RelAssertionValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-rel-token-profile-1.0.pdf#license");
		FailedAuthenticationFaultCode = LookupDictionaryString(dictionary, "FailedAuthentication");
		InvalidSecurityTokenFaultCode = LookupDictionaryString(dictionary, "InvalidSecurityToken");
		InvalidSecurityFaultCode = LookupDictionaryString(dictionary, "InvalidSecurity");
		SecurityTokenReference = LookupDictionaryString(dictionary, "SecurityTokenReference");
		Namespace = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
		Security = LookupDictionaryString(dictionary, "Security");
		ValueType = LookupDictionaryString(dictionary, "ValueType");
		TypeAttribute = LookupDictionaryString(dictionary, "Type");
		KerberosHashValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#Kerberosv5APREQSHA1");
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
