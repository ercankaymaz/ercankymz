namespace System.ServiceModel;

public static class TimeSpanHelper
{
	public static TimeSpan FromMinutes(int minutes, string text)
	{
		return TimeSpan.FromTicks(600000000L * (long)minutes);
	}

	public static TimeSpan FromSeconds(int seconds, string text)
	{
		return TimeSpan.FromTicks(10000000L * (long)seconds);
	}

	public static TimeSpan FromMilliseconds(int ms, string text)
	{
		return TimeSpan.FromTicks(10000L * (long)ms);
	}
}
