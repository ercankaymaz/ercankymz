using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime.Serialization;
using System.Xml;

namespace System.ServiceModel.Security;

internal abstract class TrustDriver
{
	public virtual bool IsIssuedTokensSupported => false;

	public virtual string IssuedTokensHeaderName
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TrustDriverVersionDoesNotSupportIssuedTokens));
		}
	}

	public virtual string IssuedTokensHeaderNamespace
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TrustDriverVersionDoesNotSupportIssuedTokens));
		}
	}

	public virtual bool IsSessionSupported => false;

	public abstract XmlDictionaryString RequestSecurityTokenAction { get; }

	public abstract XmlDictionaryString RequestSecurityTokenResponseAction { get; }

	public abstract XmlDictionaryString RequestSecurityTokenResponseFinalAction { get; }

	public virtual string RequestTypeClose
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TrustDriverVersionDoesNotSupportSession));
		}
	}

	public abstract string RequestTypeIssue { get; }

	public virtual string RequestTypeRenew
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.TrustDriverVersionDoesNotSupportSession));
		}
	}

	public abstract string ComputedKeyAlgorithm { get; }

	public abstract SecurityStandardsManager StandardsManager { get; }

	public abstract XmlDictionaryString Namespace { get; }

	public abstract RequestSecurityToken CreateRequestSecurityToken(XmlReader reader);

	public abstract RequestSecurityTokenResponse CreateRequestSecurityTokenResponse(XmlReader reader);

	public abstract RequestSecurityTokenResponseCollection CreateRequestSecurityTokenResponseCollection(XmlReader xmlReader);

	public abstract bool IsAtRequestSecurityTokenResponse(XmlReader reader);

	public abstract bool IsAtRequestSecurityTokenResponseCollection(XmlReader reader);

	public abstract bool IsRequestedSecurityTokenElement(string name, string nameSpace);

	public abstract bool IsRequestedProofTokenElement(string name, string nameSpace);

	public abstract T GetAppliesTo<T>(RequestSecurityToken rst, XmlObjectSerializer serializer);

	public abstract T GetAppliesTo<T>(RequestSecurityTokenResponse rstr, XmlObjectSerializer serializer);

	public abstract void GetAppliesToQName(RequestSecurityToken rst, out string localName, out string namespaceUri);

	public abstract void GetAppliesToQName(RequestSecurityTokenResponse rstr, out string localName, out string namespaceUri);

	public abstract bool IsAppliesTo(string localName, string namespaceUri);

	public abstract byte[] GetAuthenticator(RequestSecurityTokenResponse rstr);

	public abstract BinaryNegotiation GetBinaryNegotiation(RequestSecurityToken rst);

	public abstract BinaryNegotiation GetBinaryNegotiation(RequestSecurityTokenResponse rstr);

	public abstract SecurityToken GetEntropy(RequestSecurityToken rst, SecurityTokenResolver resolver);

	public abstract SecurityToken GetEntropy(RequestSecurityTokenResponse rstr, SecurityTokenResolver resolver);

	public abstract GenericXmlSecurityToken GetIssuedToken(RequestSecurityTokenResponse rstr, SecurityTokenResolver resolver, IList<SecurityTokenAuthenticator> allowedAuthenticators, SecurityKeyEntropyMode keyEntropyMode, byte[] requestorEntropy, string expectedTokenType, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies, int defaultKeySize, bool isBearerKeyType);

	public abstract void WriteRequestSecurityToken(RequestSecurityToken rst, XmlWriter w);

	public abstract void WriteRequestSecurityTokenResponse(RequestSecurityTokenResponse rstr, XmlWriter w);

	public abstract void WriteRequestSecurityTokenResponseCollection(RequestSecurityTokenResponseCollection rstrCollection, XmlWriter writer);
}
