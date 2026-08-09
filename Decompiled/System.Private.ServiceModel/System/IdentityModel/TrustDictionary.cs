using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class TrustDictionary
{
	public XmlDictionaryString RequestSecurityTokenResponseCollection;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString BinarySecretClauseType;

	public XmlDictionaryString CombinedHashLabel;

	public XmlDictionaryString RequestSecurityTokenResponse;

	public XmlDictionaryString TokenType;

	public XmlDictionaryString KeySize;

	public XmlDictionaryString RequestedTokenReference;

	public XmlDictionaryString AppliesTo;

	public XmlDictionaryString Authenticator;

	public XmlDictionaryString CombinedHash;

	public XmlDictionaryString BinaryExchange;

	public XmlDictionaryString Lifetime;

	public XmlDictionaryString RequestedSecurityToken;

	public XmlDictionaryString Entropy;

	public XmlDictionaryString RequestedProofToken;

	public XmlDictionaryString ComputedKey;

	public XmlDictionaryString RequestSecurityToken;

	public XmlDictionaryString RequestType;

	public XmlDictionaryString Context;

	public XmlDictionaryString BinarySecret;

	public XmlDictionaryString Type;

	public XmlDictionaryString SpnegoValueTypeUri;

	public XmlDictionaryString TlsnegoValueTypeUri;

	public XmlDictionaryString Prefix;

	public XmlDictionaryString RequestSecurityTokenIssuance;

	public XmlDictionaryString RequestSecurityTokenIssuanceResponse;

	public XmlDictionaryString RequestTypeIssue;

	public XmlDictionaryString SymmetricKeyBinarySecret;

	public XmlDictionaryString Psha1ComputedKeyUri;

	public XmlDictionaryString NonceBinarySecret;

	public XmlDictionaryString RenewTarget;

	public XmlDictionaryString CloseTarget;

	public XmlDictionaryString RequestedTokenClosed;

	public XmlDictionaryString RequestedAttachedReference;

	public XmlDictionaryString RequestedUnattachedReference;

	public XmlDictionaryString IssuedTokensHeader;

	public XmlDictionaryString RequestTypeRenew;

	public XmlDictionaryString RequestTypeClose;

	public XmlDictionaryString KeyType;

	public XmlDictionaryString SymmetricKeyType;

	public XmlDictionaryString PublicKeyType;

	public XmlDictionaryString Claims;

	public XmlDictionaryString InvalidRequestFaultCode;

	public XmlDictionaryString FailedAuthenticationFaultCode;

	public XmlDictionaryString UseKey;

	public XmlDictionaryString SignWith;

	public XmlDictionaryString EncryptWith;

	public XmlDictionaryString EncryptionAlgorithm;

	public XmlDictionaryString CanonicalizationAlgorithm;

	public XmlDictionaryString ComputedKeyAlgorithm;

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

	public TrustDictionary()
	{
	}

	public TrustDictionary(IdentityModelDictionary dictionary)
	{
	}

	public TrustDictionary(IXmlDictionary dictionary)
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
