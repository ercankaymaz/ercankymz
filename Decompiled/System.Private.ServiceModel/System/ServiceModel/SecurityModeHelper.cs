namespace System.ServiceModel;

public static class SecurityModeHelper
{
	public static bool IsDefined(SecurityMode value)
	{
		if (value != SecurityMode.None && value != SecurityMode.Transport && value != SecurityMode.Message)
		{
			return value == SecurityMode.TransportWithMessageCredential;
		}
		return true;
	}

	public static SecurityMode ToSecurityMode(UnifiedSecurityMode value)
	{
		return value switch
		{
			UnifiedSecurityMode.None => SecurityMode.None, 
			UnifiedSecurityMode.Transport => SecurityMode.Transport, 
			UnifiedSecurityMode.Message => SecurityMode.Message, 
			UnifiedSecurityMode.TransportWithMessageCredential => SecurityMode.TransportWithMessageCredential, 
			_ => (SecurityMode)value, 
		};
	}
}
