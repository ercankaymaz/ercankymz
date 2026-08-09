namespace System.ServiceModel.Channels;

internal static class ReliableMessagingConstants
{
	public static TimeSpan UnknownInitiationTime = TimeSpan.FromSeconds(2.0);

	public static TimeSpan RequestorIterationTime = TimeSpan.FromSeconds(10.0);

	public static TimeSpan RequestorReceiveTime = TimeSpan.FromSeconds(10.0);

	public static int MaxSequenceRanges = 128;
}
