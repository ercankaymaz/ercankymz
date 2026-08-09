using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

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

	public XmlDictionaryString RenewNeededFaultCode;

	public XmlDictionaryString BadContextTokenFaultCode;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString DerivedKeyTokenType;

	public XmlDictionaryString SecurityContextTokenType;

	public XmlDictionaryString SecurityContextTokenReferenceValueType;

	public XmlDictionaryString RequestSecurityContextIssuance;

	public XmlDictionaryString RequestSecurityContextIssuanceResponse;

	public XmlDictionaryString RequestSecurityContextRenew;

	public XmlDictionaryString RequestSecurityContextRenewResponse;

	public XmlDictionaryString RequestSecurityContextClose;

	public XmlDictionaryString RequestSecurityContextCloseResponse;

	public XmlDictionaryString Instance;

	public SecureConversationDictionary()
	{
	}

	public SecureConversationDictionary(IdentityModelDictionary dictionary)
	{
	}

	public SecureConversationDictionary(IXmlDictionary dictionary)
	{
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
