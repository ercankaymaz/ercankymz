namespace System.ServiceModel;

internal static class MessageCredentialTypeHelper
{
	internal static bool IsDefined(MessageCredentialType value)
	{
		if (value != MessageCredentialType.None && value != MessageCredentialType.UserName && value != MessageCredentialType.Windows && value != MessageCredentialType.Certificate)
		{
			return value == MessageCredentialType.IssuedToken;
		}
		return true;
	}
}
