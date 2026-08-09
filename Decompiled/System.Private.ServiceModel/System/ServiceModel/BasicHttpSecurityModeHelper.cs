namespace System.ServiceModel;

internal static class BasicHttpSecurityModeHelper
{
	internal static bool IsDefined(BasicHttpSecurityMode value)
	{
		if (value != BasicHttpSecurityMode.None && value != BasicHttpSecurityMode.Transport && value != BasicHttpSecurityMode.Message && value != BasicHttpSecurityMode.TransportWithMessageCredential)
		{
			return value == BasicHttpSecurityMode.TransportCredentialOnly;
		}
		return true;
	}

	internal static BasicHttpSecurityMode ToSecurityMode(UnifiedSecurityMode value)
	{
		return value switch
		{
			UnifiedSecurityMode.None => BasicHttpSecurityMode.None, 
			UnifiedSecurityMode.Transport => BasicHttpSecurityMode.Transport, 
			UnifiedSecurityMode.Message => BasicHttpSecurityMode.Message, 
			UnifiedSecurityMode.TransportWithMessageCredential => BasicHttpSecurityMode.TransportWithMessageCredential, 
			UnifiedSecurityMode.TransportCredentialOnly => BasicHttpSecurityMode.TransportCredentialOnly, 
			_ => (BasicHttpSecurityMode)value, 
		};
	}
}
