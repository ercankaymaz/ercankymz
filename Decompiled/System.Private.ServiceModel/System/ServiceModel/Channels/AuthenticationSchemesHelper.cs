using System.Net;

namespace System.ServiceModel.Channels;

internal static class AuthenticationSchemesHelper
{
	public static bool IsSingleton(this AuthenticationSchemes v)
	{
		switch (v)
		{
		case AuthenticationSchemes.Digest:
		case AuthenticationSchemes.Negotiate:
		case AuthenticationSchemes.Ntlm:
		case AuthenticationSchemes.Basic:
		case AuthenticationSchemes.Anonymous:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSet(this AuthenticationSchemes thisPtr, AuthenticationSchemes authenticationSchemes)
	{
		return (thisPtr & authenticationSchemes) == authenticationSchemes;
	}

	public static bool IsNotSet(this AuthenticationSchemes thisPtr, AuthenticationSchemes authenticationSchemes)
	{
		return (thisPtr & authenticationSchemes) == 0;
	}

	internal static string ToString(AuthenticationSchemes authScheme)
	{
		return authScheme.ToString().ToLowerInvariant();
	}
}
