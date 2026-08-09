using System;

namespace Org.BouncyCastle.Utilities.Date;

public static class DateTimeUtilities
{
	public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static readonly long MaxUnixMs = (DateTime.MaxValue.Ticks - UnixEpoch.Ticks) / 10000;

	public static readonly long MinUnixMs = 0L;

	public static long DateTimeToUnixMs(DateTime dateTime)
	{
		DateTime dateTime2 = dateTime.ToUniversalTime();
		if (dateTime2.CompareTo(UnixEpoch) < 0)
		{
			throw new ArgumentOutOfRangeException("dateTime", "DateTime value may not be before the epoch");
		}
		return (dateTime2.Ticks - UnixEpoch.Ticks) / 10000;
	}

	public static DateTime UnixMsToDateTime(long unixMs)
	{
		if (unixMs < MinUnixMs || unixMs > MaxUnixMs)
		{
			throw new ArgumentOutOfRangeException("unixMs");
		}
		return new DateTime(unixMs * 10000 + UnixEpoch.Ticks, DateTimeKind.Utc);
	}

	public static long CurrentUnixMs()
	{
		return DateTimeToUnixMs(DateTime.UtcNow);
	}

	public static DateTime WithPrecisionCentisecond(DateTime dateTime)
	{
		return new DateTime(dateTime.Ticks - dateTime.Ticks % 100000, dateTime.Kind);
	}

	public static DateTime WithPrecisionDecisecond(DateTime dateTime)
	{
		return new DateTime(dateTime.Ticks - dateTime.Ticks % 1000000, dateTime.Kind);
	}

	public static DateTime WithPrecisionMillisecond(DateTime dateTime)
	{
		return new DateTime(dateTime.Ticks - dateTime.Ticks % 10000, dateTime.Kind);
	}

	public static DateTime WithPrecisionSecond(DateTime dateTime)
	{
		return new DateTime(dateTime.Ticks - dateTime.Ticks % 10000000, dateTime.Kind);
	}
}
