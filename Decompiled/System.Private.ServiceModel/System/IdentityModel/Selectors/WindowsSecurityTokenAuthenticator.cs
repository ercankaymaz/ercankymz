using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;

namespace System.IdentityModel.Selectors;

public class WindowsSecurityTokenAuthenticator : SecurityTokenAuthenticator
{
	private bool _includeWindowsGroups;

	public WindowsSecurityTokenAuthenticator()
		: this(includeWindowsGroups: true)
	{
	}

	public WindowsSecurityTokenAuthenticator(bool includeWindowsGroups)
	{
		_includeWindowsGroups = includeWindowsGroups;
	}

	protected override bool CanValidateTokenCore(SecurityToken token)
	{
		return token is WindowsSecurityToken;
	}

	protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
	{
		WindowsSecurityToken windowsSecurityToken = (WindowsSecurityToken)token;
		WindowsClaimSet claimSet = new WindowsClaimSet(windowsSecurityToken.WindowsIdentity, windowsSecurityToken.AuthenticationType, _includeWindowsGroups, windowsSecurityToken.ValidTo);
		return SecurityUtils.CreateAuthorizationPolicies(claimSet, windowsSecurityToken.ValidTo);
	}
}
