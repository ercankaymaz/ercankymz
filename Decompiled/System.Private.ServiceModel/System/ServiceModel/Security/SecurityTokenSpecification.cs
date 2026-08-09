using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

public class SecurityTokenSpecification
{
	private ReadOnlyCollection<IAuthorizationPolicy> _tokenPolicies;

	public SecurityToken SecurityToken { get; }

	public ReadOnlyCollection<IAuthorizationPolicy> SecurityTokenPolicies => _tokenPolicies;

	public SecurityTokenSpecification(SecurityToken token, ReadOnlyCollection<IAuthorizationPolicy> tokenPolicies)
	{
		SecurityToken = token;
		_tokenPolicies = tokenPolicies ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenPolicies");
	}
}
