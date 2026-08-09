namespace System.ServiceModel.Channels;

internal class ConnectionMessageProperty
{
	public static string Name => "iconnection";

	public IConnection Connection { get; }

	public ConnectionMessageProperty(IConnection connection)
	{
		Connection = connection;
	}
}
