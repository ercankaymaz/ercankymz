using System.Net.Security;

namespace System.ServiceModel.Channels;

internal static class ConnectionOrientedTransportDefaults
{
	public const bool AllowNtlm = true;

	public const int ConnectionBufferSize = 8192;

	public const string ConnectionPoolGroupName = "default";

	public const HostNameComparisonMode HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

	public const string IdleTimeoutString = "00:02:00";

	public const string ChannelInitializationTimeoutString = "00:00:30";

	public const int MaxContentTypeSize = 256;

	public const int MaxOutboundConnectionsPerEndpoint = 10;

	public const int MaxPendingConnectionsConst = 0;

	public const string MaxOutputDelayString = "00:00:00.2";

	public const int MaxPendingAcceptsConst = 0;

	public const int MaxViaSize = 2048;

	public const ProtectionLevel ProtectionLevel = ProtectionLevel.EncryptAndSign;

	public const TransferMode TransferMode = TransferMode.Buffered;

	public static TimeSpan IdleTimeout => TimeSpanHelper.FromMinutes(2, "00:02:00");

	public static TimeSpan ChannelInitializationTimeout => TimeSpanHelper.FromSeconds(30, "00:00:30");

	public static TimeSpan MaxOutputDelay => TimeSpanHelper.FromMilliseconds(200, "00:00:00.2");

	public static int GetMaxConnections()
	{
		return GetMaxPendingConnections();
	}

	public static int GetMaxPendingConnections()
	{
		return 12 * Environment.ProcessorCount;
	}

	public static int GetMaxPendingAccepts()
	{
		return 2 * Environment.ProcessorCount;
	}
}
