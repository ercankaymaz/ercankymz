namespace System.ServiceModel.Channels;

internal static class TcpTransportDefaults
{
	public const int ListenBacklogConst = 0;

	public const string ConnectionLeaseTimeoutString = "00:05:00";

	public const bool PortSharingEnabled = false;

	public const bool TeredoEnabled = false;

	private const int ListenBacklogPre45 = 10;

	public static TimeSpan ConnectionLeaseTimeout => TimeSpanHelper.FromMinutes(5, "00:05:00");

	public static int GetListenBacklog()
	{
		return 12 * Environment.ProcessorCount;
	}
}
