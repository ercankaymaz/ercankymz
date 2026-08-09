using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class TrustDec2005Dictionary : TrustDictionary
{
	public TrustDec2005Dictionary(IdentityModelDictionary dictionary)
		: base(dictionary)
	{
		CombinedHashLabel = dictionary.CreateString("AUTH-HASH", 196);
		RequestSecurityTokenResponse = dictionary.CreateString("RequestSecurityTokenResponse", 197);
		TokenType = dictionary.CreateString("TokenType", 147);
		KeySize = dictionary.CreateString("KeySize", 198);
		RequestedTokenReference = dictionary.CreateString("RequestedTokenReference", 199);
		AppliesTo = dictionary.CreateString("AppliesTo", 200);
		Authenticator = dictionary.CreateString("Authenticator", 201);
		CombinedHash = dictionary.CreateString("CombinedHash", 202);
		BinaryExchange = dictionary.CreateString("BinaryExchange", 203);
		Lifetime = dictionary.CreateString("Lifetime", 204);
		RequestedSecurityToken = dictionary.CreateString("RequestedSecurityToken", 205);
		Entropy = dictionary.CreateString("Entropy", 206);
		RequestedProofToken = dictionary.CreateString("RequestedProofToken", 207);
		ComputedKey = dictionary.CreateString("ComputedKey", 208);
		RequestSecurityToken = dictionary.CreateString("RequestSecurityToken", 209);
		RequestType = dictionary.CreateString("RequestType", 210);
		Context = dictionary.CreateString("Context", 211);
		BinarySecret = dictionary.CreateString("BinarySecret", 212);
		Type = dictionary.CreateString("Type", 83);
		SpnegoValueTypeUri = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/spnego", 240);
		TlsnegoValueTypeUri = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/02/trust/tlsnego", 241);
		Prefix = dictionary.CreateString("trust", 242);
		RequestSecurityTokenIssuance = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Issue", 243);
		RequestSecurityTokenIssuanceResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Issue", 244);
		RequestTypeIssue = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Issue", 245);
		AsymmetricKeyBinarySecret = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/AsymmetricKey", 246);
		SymmetricKeyBinarySecret = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey", 247);
		NonceBinarySecret = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Nonce", 248);
		Psha1ComputedKeyUri = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/CK/PSHA1", 249);
		KeyType = dictionary.CreateString("KeyType", 230);
		SymmetricKeyType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey", 247);
		PublicKeyType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/PublicKey", 250);
		Claims = dictionary.CreateString("Claims", 232);
		InvalidRequestFaultCode = dictionary.CreateString("InvalidRequest", 233);
		FailedAuthenticationFaultCode = dictionary.CreateString("FailedAuthentication", 136);
		UseKey = dictionary.CreateString("UseKey", 234);
		SignWith = dictionary.CreateString("SignWith", 235);
		EncryptWith = dictionary.CreateString("EncryptWith", 236);
		EncryptionAlgorithm = dictionary.CreateString("EncryptionAlgorithm", 237);
		CanonicalizationAlgorithm = dictionary.CreateString("CanonicalizationAlgorithm", 238);
		ComputedKeyAlgorithm = dictionary.CreateString("ComputedKeyAlgorithm", 239);
		RequestSecurityTokenResponseCollection = dictionary.CreateString("RequestSecurityTokenResponseCollection", 193);
		Namespace = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512", 251);
		BinarySecretClauseType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512#BinarySecret", 252);
		RequestSecurityTokenCollectionIssuanceFinalResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTRC/IssueFinal", 253);
		RequestSecurityTokenRenewal = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Renew", 254);
		RequestSecurityTokenRenewalResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Renew", 255);
		RequestSecurityTokenCollectionRenewalFinalResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/RenewFinal", 256);
		RequestSecurityTokenCancellation = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Cancel", 257);
		RequestSecurityTokenCancellationResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Cancel", 258);
		RequestSecurityTokenCollectionCancellationFinalResponse = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/CancelFinal", 259);
		RequestTypeRenew = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Renew", 260);
		RequestTypeClose = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Cancel", 261);
		RenewTarget = dictionary.CreateString("RenewTarget", 222);
		CloseTarget = dictionary.CreateString("CancelTarget", 223);
		RequestedTokenClosed = dictionary.CreateString("RequestedTokenCancelled", 224);
		RequestedAttachedReference = dictionary.CreateString("RequestedAttachedReference", 225);
		RequestedUnattachedReference = dictionary.CreateString("RequestedUnattachedReference", 226);
		IssuedTokensHeader = dictionary.CreateString("IssuedTokens", 227);
		KeyWrapAlgorithm = dictionary.CreateString("KeyWrapAlgorithm", 262);
		BearerKeyType = dictionary.CreateString("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer", 263);
		SecondaryParameters = dictionary.CreateString("SecondaryParameters", 264);
		Dialect = dictionary.CreateString("Dialect", 265);
		DialectType = dictionary.CreateString("http://schemas.xmlsoap.org/ws/2005/05/identity", 266);
	}

	public TrustDec2005Dictionary(IXmlDictionary dictionary)
		: base(dictionary)
	{
		CombinedHashLabel = LookupDictionaryString(dictionary, "AUTH-HASH");
		RequestSecurityTokenResponse = LookupDictionaryString(dictionary, "RequestSecurityTokenResponse");
		TokenType = LookupDictionaryString(dictionary, "TokenType");
		KeySize = LookupDictionaryString(dictionary, "KeySize");
		RequestedTokenReference = LookupDictionaryString(dictionary, "RequestedTokenReference");
		AppliesTo = LookupDictionaryString(dictionary, "AppliesTo");
		Authenticator = LookupDictionaryString(dictionary, "Authenticator");
		CombinedHash = LookupDictionaryString(dictionary, "CombinedHash");
		BinaryExchange = LookupDictionaryString(dictionary, "BinaryExchange");
		Lifetime = LookupDictionaryString(dictionary, "Lifetime");
		RequestedSecurityToken = LookupDictionaryString(dictionary, "RequestedSecurityToken");
		Entropy = LookupDictionaryString(dictionary, "Entropy");
		RequestedProofToken = LookupDictionaryString(dictionary, "RequestedProofToken");
		ComputedKey = LookupDictionaryString(dictionary, "ComputedKey");
		RequestSecurityToken = LookupDictionaryString(dictionary, "RequestSecurityToken");
		RequestType = LookupDictionaryString(dictionary, "RequestType");
		Context = LookupDictionaryString(dictionary, "Context");
		BinarySecret = LookupDictionaryString(dictionary, "BinarySecret");
		Type = LookupDictionaryString(dictionary, "Type");
		SpnegoValueTypeUri = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/spnego");
		TlsnegoValueTypeUri = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/02/trust/tlsnego");
		Prefix = LookupDictionaryString(dictionary, "trust");
		RequestSecurityTokenIssuance = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Issue");
		RequestSecurityTokenIssuanceResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Issue");
		RequestTypeIssue = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Issue");
		AsymmetricKeyBinarySecret = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/AsymmetricKey");
		SymmetricKeyBinarySecret = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey");
		NonceBinarySecret = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Nonce");
		Psha1ComputedKeyUri = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/CK/PSHA1");
		KeyType = LookupDictionaryString(dictionary, "KeyType");
		SymmetricKeyType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey");
		PublicKeyType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/PublicKey");
		Claims = LookupDictionaryString(dictionary, "Claims");
		InvalidRequestFaultCode = LookupDictionaryString(dictionary, "InvalidRequest");
		FailedAuthenticationFaultCode = LookupDictionaryString(dictionary, "FailedAuthentication");
		UseKey = LookupDictionaryString(dictionary, "UseKey");
		SignWith = LookupDictionaryString(dictionary, "SignWith");
		EncryptWith = LookupDictionaryString(dictionary, "EncryptWith");
		EncryptionAlgorithm = LookupDictionaryString(dictionary, "EncryptionAlgorithm");
		CanonicalizationAlgorithm = LookupDictionaryString(dictionary, "CanonicalizationAlgorithm");
		ComputedKeyAlgorithm = LookupDictionaryString(dictionary, "ComputedKeyAlgorithm");
		RequestSecurityTokenResponseCollection = LookupDictionaryString(dictionary, "RequestSecurityTokenResponseCollection");
		Namespace = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
		BinarySecretClauseType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512#BinarySecret");
		RequestSecurityTokenCollectionIssuanceFinalResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTRC/IssueFinal");
		RequestSecurityTokenRenewal = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Renew");
		RequestSecurityTokenRenewalResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Renew");
		RequestSecurityTokenCollectionRenewalFinalResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/RenewFinal");
		RequestSecurityTokenCancellation = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Cancel");
		RequestSecurityTokenCancellationResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Cancel");
		RequestSecurityTokenCollectionCancellationFinalResponse = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/CancelFinal");
		RequestTypeRenew = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Renew");
		RequestTypeClose = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Cancel");
		RenewTarget = LookupDictionaryString(dictionary, "RenewTarget");
		CloseTarget = LookupDictionaryString(dictionary, "CancelTarget");
		RequestedTokenClosed = LookupDictionaryString(dictionary, "RequestedTokenCancelled");
		RequestedAttachedReference = LookupDictionaryString(dictionary, "RequestedAttachedReference");
		RequestedUnattachedReference = LookupDictionaryString(dictionary, "RequestedUnattachedReference");
		IssuedTokensHeader = LookupDictionaryString(dictionary, "IssuedTokens");
		KeyWrapAlgorithm = LookupDictionaryString(dictionary, "KeyWrapAlgorithm");
		BearerKeyType = LookupDictionaryString(dictionary, "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer");
		SecondaryParameters = LookupDictionaryString(dictionary, "SecondaryParameters");
		Dialect = LookupDictionaryString(dictionary, "Dialect");
		DialectType = LookupDictionaryString(dictionary, "http://schemas.xmlsoap.org/ws/2005/05/identity");
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
