namespace System.ServiceModel.Channels;

public interface IConnectionOrientedConnectionSettings
{
	int ConnectionBufferSize { get; }

	TimeSpan MaxOutputDelay { get; }

	TimeSpan IdleTimeout { get; }
}
