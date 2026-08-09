namespace System.ServiceModel;

public static class ServiceDefaults
{
	public static TimeSpan CloseTimeout => TimeSpan.FromMinutes(1.0);

	public static TimeSpan OpenTimeout => TimeSpan.FromMinutes(1.0);

	public static TimeSpan ReceiveTimeout => TimeSpan.FromMinutes(10.0);

	public static TimeSpan SendTimeout => TimeSpan.FromMinutes(1.0);
}
