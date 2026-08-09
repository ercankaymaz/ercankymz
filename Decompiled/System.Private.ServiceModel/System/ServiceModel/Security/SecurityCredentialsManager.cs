using System.IdentityModel.Selectors;

namespace System.ServiceModel.Security;

public abstract class SecurityCredentialsManager
{
	public abstract SecurityTokenManager CreateSecurityTokenManager();
}
