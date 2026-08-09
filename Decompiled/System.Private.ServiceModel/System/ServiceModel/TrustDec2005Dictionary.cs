using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel;

internal class TrustDec2005Dictionary : TrustDictionary
{
	public XmlDictionaryString AsymmetricKeyBinarySecret;

	public XmlDictionaryString RequestSecurityTokenCollectionIssuanceFinalResponse;

	public XmlDictionaryString RequestSecurityTokenRenewal;

	public XmlDictionaryString RequestSecurityTokenRenewalResponse;

	public XmlDictionaryString RequestSecurityTokenCollectionRenewalFinalResponse;

	public XmlDictionaryString RequestSecurityTokenCancellation;

	public XmlDictionaryString RequestSecurityTokenCancellationResponse;

	public XmlDictionaryString RequestSecurityTokenCollectionCancellationFinalResponse;

	public XmlDictionaryString KeyWrapAlgorithm;

	public XmlDictionaryString BearerKeyType;

	public XmlDictionaryString SecondaryParameters;

	public XmlDictionaryString Dialect;

	public XmlDictionaryString DialectType;

	public List<XmlDictionaryString> Feb2005DictionaryStrings = new List<XmlDictionaryString>();

	public List<XmlDictionaryString> Dec2005DictionaryString = new List<XmlDictionaryString>();

	public TrustDec2005Dictionary(XmlDictionary dictionary)
	{
		CombinedHashLabel = dictionary.Add("AUTH-HASH");
		RequestSecurityTokenResponse = dictionary.Add("RequestSecurityTokenResponse");
		TokenType = dictionary.Add("TokenType");
		KeySize = dictionary.Add("KeySize");
		RequestedTokenReference = dictionary.Add("RequestedTokenReference");
		AppliesTo = dictionary.Add("AppliesTo");
		Authenticator = dictionary.Add("Authenticator");
		CombinedHash = dictionary.Add("CombinedHash");
		BinaryExchange = dictionary.Add("BinaryExchange");
		Lifetime = dictionary.Add("Lifetime");
		RequestedSecurityToken = dictionary.Add("RequestedSecurityToken");
		Entropy = dictionary.Add("Entropy");
		RequestedProofToken = dictionary.Add("RequestedProofToken");
		ComputedKey = dictionary.Add("ComputedKey");
		RequestSecurityToken = dictionary.Add("RequestSecurityToken");
		RequestType = dictionary.Add("RequestType");
		Context = dictionary.Add("Context");
		BinarySecret = dictionary.Add("BinarySecret");
		Type = dictionary.Add("Type");
		SpnegoValueTypeUri = dictionary.Add("http://schemas.xmlsoap.org/ws/2005/02/trust/spnego");
		TlsnegoValueTypeUri = dictionary.Add("http://schemas.xmlsoap.org/ws/2005/02/trust/tlsnego");
		Prefix = dictionary.Add("trust");
		RequestSecurityTokenIssuance = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Issue");
		RequestSecurityTokenIssuanceResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Issue");
		RequestTypeIssue = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Issue");
		AsymmetricKeyBinarySecret = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/AsymmetricKey");
		SymmetricKeyBinarySecret = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey");
		NonceBinarySecret = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Nonce");
		Psha1ComputedKeyUri = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/CK/PSHA1");
		KeyType = dictionary.Add("KeyType");
		SymmetricKeyType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/SymmetricKey");
		PublicKeyType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/PublicKey");
		Claims = dictionary.Add("Claims");
		InvalidRequestFaultCode = dictionary.Add("InvalidRequest");
		FailedAuthenticationFaultCode = dictionary.Add("FailedAuthentication");
		UseKey = dictionary.Add("UseKey");
		SignWith = dictionary.Add("SignWith");
		EncryptWith = dictionary.Add("EncryptWith");
		EncryptionAlgorithm = dictionary.Add("EncryptionAlgorithm");
		CanonicalizationAlgorithm = dictionary.Add("CanonicalizationAlgorithm");
		ComputedKeyAlgorithm = dictionary.Add("ComputedKeyAlgorithm");
		RequestSecurityTokenResponseCollection = dictionary.Add("RequestSecurityTokenResponseCollection");
		Namespace = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512");
		BinarySecretClauseType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512#BinarySecret");
		RequestSecurityTokenCollectionIssuanceFinalResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTRC/IssueFinal");
		RequestSecurityTokenRenewal = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Renew");
		RequestSecurityTokenRenewalResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Renew");
		RequestSecurityTokenCollectionRenewalFinalResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/RenewFinal");
		RequestSecurityTokenCancellation = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RST/Cancel");
		RequestSecurityTokenCancellationResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/Cancel");
		RequestSecurityTokenCollectionCancellationFinalResponse = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/RSTR/CancelFinal");
		RequestTypeRenew = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Renew");
		RequestTypeClose = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Cancel");
		RenewTarget = dictionary.Add("RenewTarget");
		CloseTarget = dictionary.Add("CancelTarget");
		RequestedTokenClosed = dictionary.Add("RequestedTokenCancelled");
		RequestedAttachedReference = dictionary.Add("RequestedAttachedReference");
		RequestedUnattachedReference = dictionary.Add("RequestedUnattachedReference");
		IssuedTokensHeader = dictionary.Add("IssuedTokens");
		KeyWrapAlgorithm = dictionary.Add("KeyWrapAlgorithm");
		BearerKeyType = dictionary.Add("http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer");
		SecondaryParameters = dictionary.Add("SecondaryParameters");
		Dialect = dictionary.Add("Dialect");
		DialectType = dictionary.Add("http://schemas.xmlsoap.org/ws/2005/05/identity");
	}

	public void PopulateFeb2005DictionaryString()
	{
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestSecurityTokenResponseCollection);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Namespace);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.BinarySecretClauseType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.CombinedHashLabel);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestSecurityTokenResponse);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.TokenType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.KeySize);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedTokenReference);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.AppliesTo);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Authenticator);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.CombinedHash);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.BinaryExchange);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Lifetime);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedSecurityToken);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Entropy);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedProofToken);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.ComputedKey);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestSecurityToken);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Context);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.BinarySecret);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Type);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.SpnegoValueTypeUri);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.TlsnegoValueTypeUri);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Prefix);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestSecurityTokenIssuance);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestSecurityTokenIssuanceResponse);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestTypeIssue);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.SymmetricKeyBinarySecret);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Psha1ComputedKeyUri);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.NonceBinarySecret);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RenewTarget);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.CloseTarget);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedTokenClosed);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedAttachedReference);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestedUnattachedReference);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.IssuedTokensHeader);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestTypeRenew);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.RequestTypeClose);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.KeyType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.SymmetricKeyType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.PublicKeyType);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.Claims);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.InvalidRequestFaultCode);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.FailedAuthenticationFaultCode);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.UseKey);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.SignWith);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.EncryptWith);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.EncryptionAlgorithm);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.CanonicalizationAlgorithm);
		Feb2005DictionaryStrings.Add(XD.TrustFeb2005Dictionary.ComputedKeyAlgorithm);
	}

	public void PopulateDec2005DictionaryStrings()
	{
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.CombinedHashLabel);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.TokenType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.KeySize);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedTokenReference);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.AppliesTo);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Authenticator);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.CombinedHash);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.BinaryExchange);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Lifetime);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedSecurityToken);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Entropy);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedProofToken);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.ComputedKey);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityToken);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Context);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.BinarySecret);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Type);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.SpnegoValueTypeUri);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.TlsnegoValueTypeUri);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Prefix);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenIssuance);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenIssuanceResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestTypeIssue);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.AsymmetricKeyBinarySecret);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.SymmetricKeyBinarySecret);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.NonceBinarySecret);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Psha1ComputedKeyUri);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.KeyType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.SymmetricKeyType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.PublicKeyType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Claims);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.InvalidRequestFaultCode);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.FailedAuthenticationFaultCode);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.UseKey);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.SignWith);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.EncryptWith);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.EncryptionAlgorithm);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.CanonicalizationAlgorithm);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.ComputedKeyAlgorithm);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenResponseCollection);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Namespace);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.BinarySecretClauseType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenCollectionIssuanceFinalResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenRenewal);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenRenewalResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenCollectionRenewalFinalResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenCancellation);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenCancellationResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestSecurityTokenCollectionCancellationFinalResponse);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestTypeRenew);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestTypeClose);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RenewTarget);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.CloseTarget);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedTokenClosed);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedAttachedReference);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.RequestedUnattachedReference);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.IssuedTokensHeader);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.KeyWrapAlgorithm);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.BearerKeyType);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.SecondaryParameters);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.Dialect);
		Dec2005DictionaryString.Add(DXD.TrustDec2005Dictionary.DialectType);
	}
}
