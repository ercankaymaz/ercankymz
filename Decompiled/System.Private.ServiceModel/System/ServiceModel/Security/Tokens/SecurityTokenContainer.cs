using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

internal class SecurityTokenContainer
{
	public SecurityToken Token { get; }

	public SecurityTokenContainer(SecurityToken token)
	{
		Token = token ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
	}
}
