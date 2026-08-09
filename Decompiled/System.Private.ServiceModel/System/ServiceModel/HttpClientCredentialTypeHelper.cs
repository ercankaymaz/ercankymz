using System.Net;

namespace System.ServiceModel;

internal static class HttpClientCredentialTypeHelper
{
	internal static bool IsDefined(HttpClientCredentialType value)
	{
		if (value != HttpClientCredentialType.None && value != HttpClientCredentialType.Basic && value != HttpClientCredentialType.Digest && value != HttpClientCredentialType.Ntlm && value != HttpClientCredentialType.Windows && value != HttpClientCredentialType.Certificate)
		{
			return value == HttpClientCredentialType.InheritedFromHost;
		}
		return true;
	}

	internal static AuthenticationSchemes MapToAuthenticationScheme(HttpClientCredentialType clientCredentialType)
	{
		switch (clientCredentialType)
		{
		case HttpClientCredentialType.None:
		case HttpClientCredentialType.Certificate:
			return AuthenticationSchemes.Anonymous;
		case HttpClientCredentialType.Basic:
			return AuthenticationSchemes.Basic;
		case HttpClientCredentialType.Digest:
			return AuthenticationSchemes.Digest;
		case HttpClientCredentialType.Ntlm:
			return AuthenticationSchemes.Ntlm;
		case HttpClientCredentialType.Windows:
			return AuthenticationSchemes.Negotiate;
		case HttpClientCredentialType.InheritedFromHost:
			return AuthenticationSchemes.None;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
		}
	}

	internal static HttpClientCredentialType MapToClientCredentialType(AuthenticationSchemes authenticationSchemes)
	{
		switch (authenticationSchemes)
		{
		case AuthenticationSchemes.Anonymous:
			return HttpClientCredentialType.None;
		case AuthenticationSchemes.Basic:
			return HttpClientCredentialType.Basic;
		case AuthenticationSchemes.Digest:
			return HttpClientCredentialType.Digest;
		case AuthenticationSchemes.Ntlm:
			return HttpClientCredentialType.Ntlm;
		case AuthenticationSchemes.Negotiate:
		case AuthenticationSchemes.IntegratedWindowsAuthentication:
			return HttpClientCredentialType.Windows;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
		}
	}
}
