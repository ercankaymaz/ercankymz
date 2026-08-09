using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel;

internal class SecureConversationDec2005Dictionary : SecureConversationDictionary
{
	public XmlDictionaryString RequestSecurityContextRenew;

	public XmlDictionaryString RequestSecurityContextRenewResponse;

	public XmlDictionaryString RequestSecurityContextClose;

	public XmlDictionaryString RequestSecurityContextCloseResponse;

	public XmlDictionaryString Instance;

	public List<XmlDictionaryString> SecureConversationDictionaryStrings = new List<XmlDictionaryString>();

	public SecureConversationDec2005Dictionary(XmlDictionary dictionary)
	{
		SecurityContextToken = dictionary.Add("SecurityContextToken");
		AlgorithmAttribute = dictionary.Add("Algorithm");
		Generation = dictionary.Add("Generation");
		Label = dictionary.Add("Label");
		Offset = dictionary.Add("Offset");
		Properties = dictionary.Add("Properties");
		Identifier = dictionary.Add("Identifier");
		Cookie = dictionary.Add("Cookie");
		RenewNeededFaultCode = dictionary.Add("RenewNeeded");
		BadContextTokenFaultCode = dictionary.Add("BadContextToken");
		Prefix = dictionary.Add("sc");
		DerivedKeyTokenType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk");
		SecurityContextTokenType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct");
		SecurityContextTokenReferenceValueType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/sct");
		RequestSecurityContextIssuance = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT");
		RequestSecurityContextIssuanceResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT");
		RequestSecurityContextRenew = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Renew");
		RequestSecurityContextRenewResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Renew");
		RequestSecurityContextClose = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/SCT/Cancel");
		RequestSecurityContextCloseResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/SCT/Cancel");
		Namespace = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512");
		DerivedKeyToken = dictionary.Add("DerivedKeyToken");
		Nonce = dictionary.Add("Nonce");
		Length = dictionary.Add("Length");
		Instance = dictionary.Add("Instance");
	}

	public void PopulateSecureConversationDec2005()
	{
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.SecurityContextToken);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.AlgorithmAttribute);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Generation);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Label);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Offset);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Properties);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Identifier);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Cookie);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RenewNeededFaultCode);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.BadContextTokenFaultCode);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Prefix);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.DerivedKeyTokenType);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.SecurityContextTokenType);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.SecurityContextTokenReferenceValueType);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextIssuance);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextIssuanceResponse);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextRenew);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextRenewResponse);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextClose);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.RequestSecurityContextCloseResponse);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Namespace);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.DerivedKeyToken);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Nonce);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Length);
		SecureConversationDictionaryStrings.Add(DXD.SecureConversationDec2005Dictionary.Instance);
	}
}
