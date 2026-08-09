using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net;
using System.Runtime;
using System.Security.Principal;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

public class SspiSecurityTokenProvider : SecurityTokenProvider
{
	internal const bool DefaultAllowNtlm = true;

	internal const bool DefaultExtractWindowsGroupClaims = true;

	internal const bool DefaultAllowUnauthenticatedCallers = false;

	private readonly SspiSecurityToken _token;

	public SspiSecurityTokenProvider(NetworkCredential credential, bool allowNtlm, TokenImpersonationLevel impersonationLevel)
	{
		_token = new SspiSecurityToken(impersonationLevel, allowNtlm, credential);
	}

	public SspiSecurityTokenProvider(NetworkCredential credential, bool extractGroupsForWindowsAccounts, bool allowUnauthenticatedCallers)
	{
		_token = new SspiSecurityToken(credential, extractGroupsForWindowsAccounts, allowUnauthenticatedCallers);
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		return _token;
	}

	protected override IAsyncResult BeginGetTokenCore(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new CompletedAsyncResult<SecurityToken>(GetTokenCore(timeout), callback, state);
	}

	protected override SecurityToken EndGetTokenCore(IAsyncResult result)
	{
		return CompletedAsyncResult<SecurityToken>.End(result);
	}
}
