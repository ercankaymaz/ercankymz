using System.ComponentModel;
using System.Security.Authentication;

namespace System.ServiceModel.Security;

internal static class SslProtocolsHelper
{
	internal static bool IsDefined(SslProtocols value)
	{
		SslProtocols sslProtocols = SslProtocols.None;
		foreach (object value2 in Enum.GetValues(typeof(SslProtocols)))
		{
			sslProtocols |= (SslProtocols)value2;
		}
		return (value & sslProtocols) == value;
	}

	internal static void Validate(SslProtocols value)
	{
		if (!IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("value", (int)value, typeof(SslProtocols)));
		}
	}
}
