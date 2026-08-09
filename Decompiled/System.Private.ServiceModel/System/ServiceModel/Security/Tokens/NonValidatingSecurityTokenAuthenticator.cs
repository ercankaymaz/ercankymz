using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

internal class NonValidatingSecurityTokenAuthenticator<TTokenType> : SecurityTokenAuthenticator
{
	protected override bool CanValidateTokenCore(SecurityToken token)
	{
		return token is TTokenType;
	}

	protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
	{
		return EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
	}
}
