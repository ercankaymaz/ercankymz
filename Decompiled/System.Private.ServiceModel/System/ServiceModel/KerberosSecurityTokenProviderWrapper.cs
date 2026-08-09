using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Authentication.ExtendedProtection;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel;

internal class KerberosSecurityTokenProviderWrapper : CommunicationObjectSecurityTokenProvider
{
	private KerberosSecurityTokenProvider _innerProvider;

	public KerberosSecurityTokenProviderWrapper(KerberosSecurityTokenProvider innerProvider)
	{
		_innerProvider = innerProvider;
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		return new KerberosRequestorSecurityToken(_innerProvider.ServicePrincipalName, _innerProvider.TokenImpersonationLevel, _innerProvider.NetworkCredential, SecurityUniqueId.Create().Value);
	}

	internal Task<SecurityToken> GetTokenAsync(TimeSpan timeout, ChannelBinding channelbinding)
	{
		return Task.FromResult(GetTokenCore(timeout));
	}

	internal override Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		return GetTokenAsync(timeout, null);
	}
}
