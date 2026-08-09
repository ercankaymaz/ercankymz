using System.IdentityModel.Selectors;
using System.Runtime.CompilerServices;

namespace System.ServiceModel.Security.Tokens;

internal class SecurityTokenProviderContainer
{
	public SecurityTokenProvider TokenProvider { get; }

	public SecurityTokenProviderContainer(SecurityTokenProvider tokenProvider)
	{
		TokenProvider = tokenProvider ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenProvider");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Close(TimeSpan timeout)
	{
		SecurityUtils.CloseTokenProviderIfRequired(TokenProvider, timeout);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Open(TimeSpan timeout)
	{
		SecurityUtils.OpenTokenProviderIfRequired(TokenProvider, timeout);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Abort()
	{
		SecurityUtils.AbortTokenProviderIfRequired(TokenProvider);
	}
}
