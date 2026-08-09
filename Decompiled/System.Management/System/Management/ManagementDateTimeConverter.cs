namespace System.Management;

public sealed class ManagementDateTimeConverter
{
	internal ManagementDateTimeConverter()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public static DateTime ToDateTime(string dmtfDate)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public static string ToDmtfDateTime(DateTime date)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public static string ToDmtfTimeInterval(TimeSpan timespan)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public static TimeSpan ToTimeSpan(string dmtfTimespan)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
