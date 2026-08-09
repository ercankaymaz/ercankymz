namespace System.ServiceModel;

internal static class BasicHttpsSecurityModeHelper
{
	internal static bool IsDefined(BasicHttpsSecurityMode value)
	{
		if (value != BasicHttpsSecurityMode.Transport)
		{
			return value == BasicHttpsSecurityMode.TransportWithMessageCredential;
		}
		return true;
	}

	internal static BasicHttpsSecurityMode ToSecurityMode(UnifiedSecurityMode value)
	{
		return value switch
		{
			UnifiedSecurityMode.Transport => BasicHttpsSecurityMode.Transport, 
			UnifiedSecurityMode.TransportWithMessageCredential => BasicHttpsSecurityMode.TransportWithMessageCredential, 
			_ => (BasicHttpsSecurityMode)value, 
		};
	}

	internal static BasicHttpsSecurityMode ToBasicHttpsSecurityMode(BasicHttpSecurityMode mode)
	{
		return (mode != BasicHttpSecurityMode.Transport) ? BasicHttpsSecurityMode.TransportWithMessageCredential : BasicHttpsSecurityMode.Transport;
	}

	internal static BasicHttpSecurityMode ToBasicHttpSecurityMode(BasicHttpsSecurityMode mode)
	{
		if (!IsDefined(mode))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("mode"));
		}
		return (mode == BasicHttpsSecurityMode.Transport) ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.TransportWithMessageCredential;
	}
}
