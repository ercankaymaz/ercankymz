using System.Net.Security;

namespace System.ServiceModel.Channels;

internal static class AuthenticationLevelHelper
{
	internal static string ToString(AuthenticationLevel authenticationLevel)
	{
		return authenticationLevel switch
		{
			AuthenticationLevel.MutualAuthRequested => "mutualAuthRequested", 
			AuthenticationLevel.MutualAuthRequired => "mutualAuthRequired", 
			AuthenticationLevel.None => "none", 
			_ => authenticationLevel.ToString(), 
		};
	}
}
