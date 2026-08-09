using System.Xml;

namespace System.ServiceModel;

internal class SecureConversationFeb2005Dictionary : SecureConversationDictionary
{
	public XmlDictionaryString RequestSecurityContextRenew;

	public XmlDictionaryString RequestSecurityContextRenewResponse;

	public XmlDictionaryString RequestSecurityContextClose;

	public XmlDictionaryString RequestSecurityContextCloseResponse;

	public SecureConversationFeb2005Dictionary(ServiceModelDictionary dictionary)
		: base(dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc", 38);
		DerivedKeyToken = dictionary.CreateString("DerivedKeyToken", 39);
		Nonce = dictionary.CreateString("Nonce", 40);
		Length = dictionary.CreateString("Length", 56);
		SecurityContextToken = dictionary.CreateString("SecurityContextToken", 115);
		AlgorithmAttribute = dictionary.CreateString("Algorithm", 8);
		Generation = dictionary.CreateString("Generation", 116);
		Label = dictionary.CreateString("Label", 117);
		Offset = dictionary.CreateString("Offset", 118);
		Properties = dictionary.CreateString("Properties", 119);
		Identifier = dictionary.CreateString("Identifier", 15);
		Cookie = dictionary.CreateString("Cookie", 120);
		RenewNeededFaultCode = dictionary.CreateString("RenewNeeded", 127);
		BadContextTokenFaultCode = dictionary.CreateString("BadContextToken", 128);
		Prefix = dictionary.CreateString("c", 129);
		DerivedKeyTokenType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/dk", 130);
		SecurityContextTokenType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/sct", 131);
		SecurityContextTokenReferenceValueType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/sc/sct", 131);
		RequestSecurityContextIssuance = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT", 132);
		RequestSecurityContextIssuanceResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT", 133);
		RequestSecurityContextRenew = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Renew", 134);
		RequestSecurityContextRenewResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Renew", 135);
		RequestSecurityContextClose = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/SCT/Cancel", 136);
		RequestSecurityContextCloseResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/SCT/Cancel", 137);
	}
}
