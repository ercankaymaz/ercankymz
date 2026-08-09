using System.Net;

namespace System.ServiceModel;

internal static class HttpProxyCredentialTypeHelper
{
	internal static bool IsDefined(HttpProxyCredentialType value)
	{
		if (value != HttpProxyCredentialType.None && value != HttpProxyCredentialType.Basic && value != HttpProxyCredentialType.Digest && value != HttpProxyCredentialType.Ntlm)
		{
			return value == HttpProxyCredentialType.Windows;
		}
		return true;
	}

	internal static AuthenticationSchemes MapToAuthenticationScheme(HttpProxyCredentialType proxyCredentialType)
	{
		return proxyCredentialType switch
		{
			HttpProxyCredentialType.None => AuthenticationSchemes.Anonymous, 
			HttpProxyCredentialType.Basic => AuthenticationSchemes.Basic, 
			HttpProxyCredentialType.Digest => AuthenticationSchemes.Digest, 
			HttpProxyCredentialType.Ntlm => AuthenticationSchemes.Ntlm, 
			HttpProxyCredentialType.Windows => AuthenticationSchemes.Negotiate, 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
		};
	}

	internal static HttpProxyCredentialType MapToProxyCredentialType(AuthenticationSchemes authenticationSchemes)
	{
		return authenticationSchemes switch
		{
			AuthenticationSchemes.Anonymous => HttpProxyCredentialType.None, 
			AuthenticationSchemes.Basic => HttpProxyCredentialType.Basic, 
			AuthenticationSchemes.Digest => HttpProxyCredentialType.Digest, 
			AuthenticationSchemes.Ntlm => HttpProxyCredentialType.Ntlm, 
			AuthenticationSchemes.Negotiate => HttpProxyCredentialType.Windows, 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException()), 
		};
	}
}
