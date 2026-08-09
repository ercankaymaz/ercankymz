namespace System.ServiceModel.Channels;

internal class ChannelDemuxer
{
	public static readonly TimeSpan UseDefaultReceiveTimeout = TimeSpan.MinValue;

	public TimeSpan PeekTimeout { get; set; }

	public int MaxPendingSessions { get; set; }

	public ChannelDemuxer()
	{
		PeekTimeout = UseDefaultReceiveTimeout;
		MaxPendingSessions = 10;
	}
}
