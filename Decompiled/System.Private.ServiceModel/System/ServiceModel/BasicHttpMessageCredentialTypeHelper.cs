namespace System.ServiceModel;

internal static class BasicHttpMessageCredentialTypeHelper
{
	internal static bool IsDefined(BasicHttpMessageCredentialType value)
	{
		if (value != BasicHttpMessageCredentialType.UserName)
		{
			return value == BasicHttpMessageCredentialType.Certificate;
		}
		return true;
	}
}
