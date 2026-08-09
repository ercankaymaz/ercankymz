namespace System.ServiceModel.Channels;

internal static class OneWayDefaults
{
	public const string IdleTimeoutString = "00:02:00";

	public const int MaxOutboundChannelsPerEndpoint = 10;

	public const string LeaseTimeoutString = "00:10:00";

	public const int MaxAcceptedChannels = 10;

	public const bool PacketRoutable = false;

	public static TimeSpan IdleTimeout => TimeSpanHelper.FromMinutes(2, "00:02:00");

	public static TimeSpan LeaseTimeout => TimeSpanHelper.FromMinutes(10, "00:10:00");
}
