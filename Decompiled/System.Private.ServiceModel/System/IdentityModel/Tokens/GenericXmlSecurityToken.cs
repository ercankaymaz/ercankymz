using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IdentityModel.Policy;
using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel.Tokens;

public class GenericXmlSecurityToken : SecurityToken
{
	private const int SupportedPersistanceVersion = 1;

	private string _id;

	private DateTime _effectiveTime;

	private DateTime _expirationTime;

	public override string Id => _id;

	public override DateTime ValidFrom => _effectiveTime;

	public override DateTime ValidTo => _expirationTime;

	public SecurityKeyIdentifierClause InternalTokenReference { get; }

	public SecurityKeyIdentifierClause ExternalTokenReference { get; }

	public XmlElement TokenXml { get; }

	public SecurityToken ProofToken { get; }

	public ReadOnlyCollection<IAuthorizationPolicy> AuthorizationPolicies { get; }

	public override ReadOnlyCollection<SecurityKey> SecurityKeys
	{
		get
		{
			if (ProofToken != null)
			{
				return ProofToken.SecurityKeys;
			}
			return EmptyReadOnlyCollection<SecurityKey>.Instance;
		}
	}

	public GenericXmlSecurityToken(XmlElement tokenXml, SecurityToken proofToken, DateTime effectiveTime, DateTime expirationTime, SecurityKeyIdentifierClause internalTokenReference, SecurityKeyIdentifierClause externalTokenReference, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		if (tokenXml == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenXml");
		}
		_id = GetId(tokenXml);
		TokenXml = tokenXml;
		ProofToken = proofToken;
		_effectiveTime = effectiveTime.ToUniversalTime();
		_expirationTime = expirationTime.ToUniversalTime();
		InternalTokenReference = internalTokenReference;
		ExternalTokenReference = externalTokenReference;
		AuthorizationPolicies = authorizationPolicies ?? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
	}

	public override string ToString()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		stringWriter.WriteLine("Generic XML token:");
		stringWriter.WriteLine("   validFrom: {0}", ValidFrom);
		stringWriter.WriteLine("   validTo: {0}", ValidTo);
		if (InternalTokenReference != null)
		{
			stringWriter.WriteLine("   InternalTokenReference: {0}", InternalTokenReference);
		}
		if (ExternalTokenReference != null)
		{
			stringWriter.WriteLine("   ExternalTokenReference: {0}", ExternalTokenReference);
		}
		stringWriter.WriteLine("   Token Element: ({0}, {1})", TokenXml.LocalName, TokenXml.NamespaceURI);
		return stringWriter.ToString();
	}

	private static string GetId(XmlElement tokenXml)
	{
		if (tokenXml != null)
		{
			string attribute = tokenXml.GetAttribute("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
			if (string.IsNullOrEmpty(attribute))
			{
				attribute = tokenXml.GetAttribute("AssertionID");
				if (string.IsNullOrEmpty(attribute))
				{
					attribute = tokenXml.GetAttribute("Id");
				}
				if (string.IsNullOrEmpty(attribute))
				{
					attribute = tokenXml.GetAttribute("ID");
				}
			}
			if (!string.IsNullOrEmpty(attribute))
			{
				return attribute;
			}
		}
		return null;
	}

	public override bool CanCreateKeyIdentifierClause<T>()
	{
		if (InternalTokenReference != null && typeof(T) == InternalTokenReference.GetType())
		{
			return true;
		}
		if (ExternalTokenReference != null && typeof(T) == ExternalTokenReference.GetType())
		{
			return true;
		}
		return false;
	}

	public override T CreateKeyIdentifierClause<T>()
	{
		if (InternalTokenReference != null && typeof(T) == InternalTokenReference.GetType())
		{
			return (T)InternalTokenReference;
		}
		if (ExternalTokenReference != null && typeof(T) == ExternalTokenReference.GetType())
		{
			return (T)ExternalTokenReference;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenException(System.SR.UnableToCreateTokenReference));
	}

	public override bool MatchesKeyIdentifierClause(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		if (InternalTokenReference != null && InternalTokenReference.Matches(keyIdentifierClause))
		{
			return true;
		}
		if (ExternalTokenReference != null && ExternalTokenReference.Matches(keyIdentifierClause))
		{
			return true;
		}
		return false;
	}
}
