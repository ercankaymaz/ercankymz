using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

internal class GenericXmlSecurityTokenAuthenticator : SecurityTokenAuthenticator
{
	protected override bool CanValidateTokenCore(SecurityToken token)
	{
		return token is GenericXmlSecurityToken;
	}

	protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
	{
		GenericXmlSecurityToken genericXmlSecurityToken = (GenericXmlSecurityToken)token;
		return genericXmlSecurityToken.AuthorizationPolicies;
	}
}
