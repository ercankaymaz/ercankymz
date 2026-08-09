using System.IdentityModel.Tokens;
using System.Runtime;
using System.ServiceModel;
using System.Threading.Tasks;

namespace System.IdentityModel.Selectors;

public abstract class SecurityTokenProvider
{
	public virtual bool SupportsTokenRenewal => false;

	public virtual bool SupportsTokenCancellation => false;

	public SecurityToken GetToken(TimeSpan timeout)
	{
		SecurityToken tokenCore = GetTokenCore(timeout);
		if (tokenCore == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToGetToken, this)));
		}
		return tokenCore;
	}

	public IAsyncResult BeginGetToken(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return BeginGetTokenCore(timeout, callback, state);
	}

	public SecurityToken EndGetToken(IAsyncResult result)
	{
		if (result == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("result");
		}
		SecurityToken securityToken = EndGetTokenCore(result);
		if (securityToken == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToGetToken, this)));
		}
		return securityToken;
	}

	public async Task<SecurityToken> GetTokenAsync(TimeSpan timeout)
	{
		SecurityToken securityToken = await GetTokenCoreAsync(timeout);
		if (securityToken == null)
		{
			throw Fx.Exception.AsError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToGetToken, this)));
		}
		return securityToken;
	}

	protected abstract SecurityToken GetTokenCore(TimeSpan timeout);

	protected virtual IAsyncResult BeginGetTokenCore(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return GetTokenCoreInternalAsync(timeout).ToApm(callback, state);
	}

	protected virtual SecurityToken EndGetTokenCore(IAsyncResult result)
	{
		return result.ToApmEnd<SecurityToken>();
	}

	protected virtual Task<SecurityToken> GetTokenCoreAsync(TimeSpan timeout)
	{
		return Task<SecurityToken>.Factory.FromAsync(BeginGetTokenCore, EndGetTokenCore, timeout, null);
	}

	internal virtual Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		return Task.FromResult(GetTokenCore(timeout));
	}

	public SecurityToken RenewToken(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		if (tokenToBeRenewed == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenToBeRenewed");
		}
		SecurityToken securityToken = RenewTokenCore(timeout, tokenToBeRenewed);
		if (securityToken == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToRenewToken, this)));
		}
		return securityToken;
	}

	public IAsyncResult BeginRenewToken(TimeSpan timeout, SecurityToken tokenToBeRenewed, AsyncCallback callback, object state)
	{
		if (tokenToBeRenewed == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenToBeRenewed");
		}
		return BeginRenewTokenCore(timeout, tokenToBeRenewed, callback, state);
	}

	public SecurityToken EndRenewToken(IAsyncResult result)
	{
		if (result == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("result");
		}
		SecurityToken securityToken = EndRenewTokenCore(result);
		if (securityToken == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToRenewToken, this)));
		}
		return securityToken;
	}

	public async Task<SecurityToken> RenewTokenAsync(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		if (tokenToBeRenewed == null)
		{
			throw Fx.Exception.ArgumentNull("tokenToBeRenewed");
		}
		SecurityToken securityToken = await RenewTokenCoreAsync(timeout, tokenToBeRenewed);
		if (securityToken == null)
		{
			throw Fx.Exception.AsError(new SecurityTokenException(System.SR.Format(System.SR.TokenProviderUnableToRenewToken, this)));
		}
		return securityToken;
	}

	protected virtual SecurityToken RenewTokenCore(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.TokenRenewalNotSupported, this)));
	}

	protected virtual IAsyncResult BeginRenewTokenCore(TimeSpan timeout, SecurityToken tokenToBeRenewed, AsyncCallback callback, object state)
	{
		return RenewTokenCoreInternalAsync(timeout, tokenToBeRenewed).ToApm(callback, state);
	}

	protected virtual SecurityToken EndRenewTokenCore(IAsyncResult result)
	{
		return result.ToApmEnd<SecurityToken>();
	}

	protected virtual Task<SecurityToken> RenewTokenCoreAsync(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		return Task<SecurityToken>.Factory.FromAsync(BeginRenewTokenCore, EndRenewTokenCore, timeout, tokenToBeRenewed, null);
	}

	internal virtual Task<SecurityToken> RenewTokenCoreInternalAsync(TimeSpan timeout, SecurityToken tokenToBeRenewed)
	{
		return Task.FromResult(RenewTokenCore(timeout, tokenToBeRenewed));
	}

	public void CancelToken(TimeSpan timeout, SecurityToken token)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		CancelTokenCore(timeout, token);
	}

	public IAsyncResult BeginCancelToken(TimeSpan timeout, SecurityToken token, AsyncCallback callback, object state)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		return BeginCancelTokenCore(timeout, token, callback, state);
	}

	public void EndCancelToken(IAsyncResult result)
	{
		if (result == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("result");
		}
		EndCancelTokenCore(result);
	}

	public async Task CancelTokenAsync(TimeSpan timeout, SecurityToken token)
	{
		if (token == null)
		{
			throw Fx.Exception.ArgumentNull("token");
		}
		await CancelTokenCoreAsync(timeout, token);
	}

	protected virtual void CancelTokenCore(TimeSpan timeout, SecurityToken token)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.TokenCancellationNotSupported, this)));
	}

	protected virtual IAsyncResult BeginCancelTokenCore(TimeSpan timeout, SecurityToken token, AsyncCallback callback, object state)
	{
		return CancelTokenCoreInternalAsync(timeout, token).ToApm(callback, state);
	}

	protected virtual void EndCancelTokenCore(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	protected virtual Task CancelTokenCoreAsync(TimeSpan timeout, SecurityToken token)
	{
		return Task.Factory.FromAsync(BeginCancelTokenCore, EndCancelTokenCore, timeout, token, null);
	}

	internal virtual Task CancelTokenCoreInternalAsync(TimeSpan timeout, SecurityToken token)
	{
		CancelTokenCore(timeout, token);
		return Task.CompletedTask;
	}
}
