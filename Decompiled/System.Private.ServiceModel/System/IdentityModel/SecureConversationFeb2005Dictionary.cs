using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SecureConversationFeb2005Dictionary : SecureConversationDictionary
{
	public SecureConversationFeb2005Dictionary(IdentityModelDictionary dictionary)
		: base(dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc", 172);
		DerivedKeyToken = dictionary.CreateString("DerivedKeyToken", 173);
		Nonce = dictionary.CreateString("Nonce", 120);
		Length = dictionary.CreateString("Length", 174);
		SecurityContextToken = dictionary.CreateString("SecurityContextToken", 175);
		AlgorithmAttribute = dictionary.CreateString("Algorithm", 0);
		Generation = dictionary.CreateString("Generation", 176);
		Label = dictionary.CreateString("Label", 177);
		Offset = dictionary.CreateString("Offset", 178);
		Properties = dictionary.CreateString("Properties", 179);
		Identifier = dictionary.CreateString("Identifier", 180);
		Cookie = dictionary.CreateString("Cookie", 181);
		RenewNeededFaultCode = dictionary.CreateString("RenewNeeded", 182);
		BadContextTokenFaultCode = dictionary.CreateString("BadContextToken", 183);
		Prefix = dictionary.CreateString("c", 184);
		DerivedKeyTokenType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/dk", 185);
		SecurityContextTokenType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/sct", 186);
		SecurityContextTokenReferenceValueType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/sct", 186);
		RequestSecurityContextIssuance = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT", 187);
		RequestSecurityContextIssuanceResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT", 188);
		RequestSecurityContextRenew = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Renew", 189);
		RequestSecurityContextRenewResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Renew", 190);
		RequestSecurityContextClose = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Cancel", 191);
		RequestSecurityContextCloseResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Cancel", 192);
	}

	public SecureConversationFeb2005Dictionary(IXmlDictionary dictionary)
		: base(dictionary)
	{
		Namespace = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/sc");
		DerivedKeyToken = LookupDictionaryString(dictionary, "DerivedKeyToken");
		Nonce = LookupDictionaryString(dictionary, "Nonce");
		Length = LookupDictionaryString(dictionary, "Length");
		SecurityContextToken = LookupDictionaryString(dictionary, "SecurityContextToken");
		AlgorithmAttribute = LookupDictionaryString(dictionary, "Algorithm");
		Generation = LookupDictionaryString(dictionary, "Generation");
		Label = LookupDictionaryString(dictionary, "Label");
		Offset = LookupDictionaryString(dictionary, "Offset");
		Properties = LookupDictionaryString(dictionary, "Properties");
		Identifier = LookupDictionaryString(dictionary, "Identifier");
		Cookie = LookupDictionaryString(dictionary, "Cookie");
		RenewNeededFaultCode = LookupDictionaryString(dictionary, "RenewNeeded");
		BadContextTokenFaultCode = LookupDictionaryString(dictionary, "BadContextToken");
		Prefix = LookupDictionaryString(dictionary, "c");
		DerivedKeyTokenType = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/sc/dk");
		SecurityContextTokenType = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/sc/sct");
		SecurityContextTokenReferenceValueType = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/sc/sct");
		RequestSecurityContextIssuance = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT");
		RequestSecurityContextIssuanceResponse = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT");
		RequestSecurityContextRenew = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Renew");
		RequestSecurityContextRenewResponse = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Renew");
		RequestSecurityContextClose = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Cancel");
		RequestSecurityContextCloseResponse = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Cancel");
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
