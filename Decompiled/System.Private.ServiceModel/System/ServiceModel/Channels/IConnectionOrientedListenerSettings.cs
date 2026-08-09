namespace System.ServiceModel.Channels;

internal interface IConnectionOrientedListenerSettings : IConnectionOrientedConnectionSettings
{
	TimeSpan ChannelInitializationTimeout { get; }

	int MaxPendingConnections { get; }

	int MaxPendingAccepts { get; }

	int MaxPooledConnections { get; }
}
