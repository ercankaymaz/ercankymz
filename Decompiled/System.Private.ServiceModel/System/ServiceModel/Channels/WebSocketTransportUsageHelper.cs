using System.ComponentModel;

namespace System.ServiceModel.Channels;

internal static class WebSocketTransportUsageHelper
{
	internal static bool IsDefined(WebSocketTransportUsage value)
	{
		if (value != WebSocketTransportUsage.WhenDuplex && value != WebSocketTransportUsage.Never)
		{
			return value == WebSocketTransportUsage.Always;
		}
		return true;
	}

	internal static void Validate(WebSocketTransportUsage value)
	{
		if (!IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("value", (int)value, typeof(WebSocketTransportUsage)));
		}
	}
}
