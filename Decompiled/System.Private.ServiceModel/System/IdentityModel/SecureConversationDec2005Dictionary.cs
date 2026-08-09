using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SecureConversationDec2005Dictionary : SecureConversationDictionary
{
	public SecureConversationDec2005Dictionary(IdentityModelDictionary dictionary)
		: base(dictionary)
	{
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
		Prefix = dictionary.CreateString("sc", 268);
		DerivedKeyTokenType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk", 269);
		SecurityContextTokenType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct", 270);
		SecurityContextTokenReferenceValueType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct", 270);
		RequestSecurityContextIssuance = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT", 271);
		RequestSecurityContextIssuanceResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT", 272);
		RequestSecurityContextRenew = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Renew", 273);
		RequestSecurityContextRenewResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Renew", 274);
		RequestSecurityContextClose = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Cancel", 275);
		RequestSecurityContextCloseResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Cancel", 276);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512", 277);
		DerivedKeyToken = dictionary.CreateString("DerivedKeyToken", 173);
		Nonce = dictionary.CreateString("Nonce", 120);
		Length = dictionary.CreateString("Length", 174);
		Instance = dictionary.CreateString("Instance", 278);
	}

	public SecureConversationDec2005Dictionary(IXmlDictionary dictionary)
		: base(dictionary)
	{
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
		Prefix = LookupDictionaryString(dictionary, "sc");
		DerivedKeyTokenType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk");
		SecurityContextTokenType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct");
		SecurityContextTokenReferenceValueType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct");
		RequestSecurityContextIssuance = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT");
		RequestSecurityContextIssuanceResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT");
		RequestSecurityContextRenew = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Renew");
		RequestSecurityContextRenewResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Renew");
		RequestSecurityContextClose = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Cancel");
		RequestSecurityContextCloseResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Cancel");
		Namespace = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512");
		DerivedKeyToken = LookupDictionaryString(dictionary, "DerivedKeyToken");
		Nonce = LookupDictionaryString(dictionary, "Nonce");
		Length = LookupDictionaryString(dictionary, "Length");
		Instance = LookupDictionaryString(dictionary, "Instance");
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
