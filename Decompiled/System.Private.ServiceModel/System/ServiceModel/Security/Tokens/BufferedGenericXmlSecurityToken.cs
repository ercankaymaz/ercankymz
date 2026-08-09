using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Xml;

namespace System.ServiceModel.Security.Tokens;

internal class BufferedGenericXmlSecurityToken : GenericXmlSecurityToken
{
	public XmlBuffer TokenXmlBuffer { get; }

	public BufferedGenericXmlSecurityToken(XmlElement tokenXml, SecurityToken proofToken, DateTime effectiveTime, DateTime expirationTime, SecurityKeyIdentifierClause internalTokenReference, SecurityKeyIdentifierClause externalTokenReference, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies, XmlBuffer tokenXmlBuffer)
		: base(tokenXml, proofToken, effectiveTime, expirationTime, internalTokenReference, externalTokenReference, authorizationPolicies)
	{
		TokenXmlBuffer = tokenXmlBuffer;
	}
}
