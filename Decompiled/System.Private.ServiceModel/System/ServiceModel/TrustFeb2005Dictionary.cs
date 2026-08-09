namespace System.ServiceModel;

internal class TrustFeb2005Dictionary : TrustDictionary
{
	public TrustFeb2005Dictionary(ServiceModelDictionary dictionary)
		: base(dictionary)
	{
		RequestSecurityTokenResponseCollection = dictionary.CreateString("RequestSecurityTokenResponseCollection", 62);
		Namespace = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust", 63);
		BinarySecretClauseType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust#BinarySecret", 64);
		CombinedHashLabel = dictionary.CreateString("AUTH-HASH", 194);
		RequestSecurityTokenResponse = dictionary.CreateString("RequestSecurityTokenResponse", 195);
		TokenType = dictionary.CreateString("TokenType", 187);
		KeySize = dictionary.CreateString("KeySize", 196);
		RequestedTokenReference = dictionary.CreateString("RequestedTokenReference", 197);
		AppliesTo = dictionary.CreateString("AppliesTo", 198);
		Authenticator = dictionary.CreateString("Authenticator", 199);
		CombinedHash = dictionary.CreateString("CombinedHash", 200);
		BinaryExchange = dictionary.CreateString("BinaryExchange", 201);
		Lifetime = dictionary.CreateString("Lifetime", 202);
		RequestedSecurityToken = dictionary.CreateString("RequestedSecurityToken", 203);
		Entropy = dictionary.CreateString("Entropy", 204);
		RequestedProofToken = dictionary.CreateString("RequestedProofToken", 205);
		ComputedKey = dictionary.CreateString("ComputedKey", 206);
		RequestSecurityToken = dictionary.CreateString("RequestSecurityToken", 207);
		RequestType = dictionary.CreateString("RequestType", 208);
		Context = dictionary.CreateString("Context", 209);
		BinarySecret = dictionary.CreateString("BinarySecret", 210);
		Type = dictionary.CreateString("Type", 59);
		SpnegoValueTypeUri = dictionary.CreateString("http://schemas.microsoft.com/net/2004/07/secext/WS-SPNego", 233);
		TlsnegoValueTypeUri = dictionary.CreateString("http://schemas.microsoft.com/net/2004/07/secext/TLSNego", 234);
		Prefix = dictionary.CreateString("t", 235);
		RequestSecurityTokenIssuance = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue", 236);
		RequestSecurityTokenIssuanceResponse = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue", 237);
		RequestTypeIssue = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/Issue", 238);
		SymmetricKeyBinarySecret = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/SymmetricKey", 239);
		Psha1ComputedKeyUri = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/CK/PSHA1", 240);
		NonceBinarySecret = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/Nonce", 241);
		RenewTarget = dictionary.CreateString("RenewTarget", 242);
		CloseTarget = dictionary.CreateString("CancelTarget", 243);
		RequestedTokenClosed = dictionary.CreateString("RequestedTokenCancelled", 244);
		RequestedAttachedReference = dictionary.CreateString("RequestedAttachedReference", 245);
		RequestedUnattachedReference = dictionary.CreateString("RequestedUnattachedReference", 246);
		IssuedTokensHeader = dictionary.CreateString("IssuedTokens", 247);
		RequestTypeRenew = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/Renew", 248);
		RequestTypeClose = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/Cancel", 249);
		KeyType = dictionary.CreateString("KeyType", 221);
		SymmetricKeyType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/SymmetricKey", 239);
		PublicKeyType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/PublicKey", 250);
		Claims = dictionary.CreateString("Claims", 224);
		InvalidRequestFaultCode = dictionary.CreateString("InvalidRequest", 225);
		FailedAuthenticationFaultCode = dictionary.CreateString("FailedAuthentication", 182);
		UseKey = dictionary.CreateString("UseKey", 232);
		SignWith = dictionary.CreateString("SignWith", 227);
		EncryptWith = dictionary.CreateString("EncryptWith", 228);
		EncryptionAlgorithm = dictionary.CreateString("EncryptionAlgorithm", 229);
		CanonicalizationAlgorithm = dictionary.CreateString("CanonicalizationAlgorithm", 230);
		ComputedKeyAlgorithm = dictionary.CreateString("ComputedKeyAlgorithm", 231);
	}
}
