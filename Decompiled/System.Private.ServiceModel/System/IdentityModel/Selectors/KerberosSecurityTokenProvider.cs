using System.IdentityModel.Tokens;
using System.Net;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading.Tasks;

namespace System.IdentityModel.Selectors;

public class KerberosSecurityTokenProvider : SecurityTokenProvider
{
	private readonly NetworkCredential _networkCredential;

	public string ServicePrincipalName { get; }

	public TokenImpersonationLevel TokenImpersonationLevel { get; }

	public NetworkCredential NetworkCredential => _networkCredential;

	public KerberosSecurityTokenProvider(string servicePrincipalName)
		: this(servicePrincipalName, TokenImpersonationLevel.Identification)
	{
	}

	public KerberosSecurityTokenProvider(string servicePrincipalName, TokenImpersonationLevel tokenImpersonationLevel)
		: this(servicePrincipalName, tokenImpersonationLevel, null)
	{
	}

	public KerberosSecurityTokenProvider(string servicePrincipalName, TokenImpersonationLevel tokenImpersonationLevel, NetworkCredential networkCredential)
	{
		if (tokenImpersonationLevel != TokenImpersonationLevel.Identification && tokenImpersonationLevel != TokenImpersonationLevel.Impersonation)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("tokenImpersonationLevel", System.SR.Format(System.SR.ImpersonationLevelNotSupported, tokenImpersonationLevel)));
		}
		ServicePrincipalName = servicePrincipalName ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("servicePrincipalName");
		TokenImpersonationLevel = tokenImpersonationLevel;
		_networkCredential = networkCredential;
	}

	internal SecurityToken GetToken(TimeSpan timeout, ChannelBinding channelbinding)
	{
		return new KerberosRequestorSecurityToken(ServicePrincipalName, TokenImpersonationLevel, NetworkCredential, SecurityUniqueId.Create().Value);
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		return GetToken(timeout, null);
	}

	internal override Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		return Task.FromResult(GetToken(timeout, null));
	}
}
