using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class BufferedConnectionInitiator : IConnectionInitiator
{
	private IConnectionInitiator _connectionInitiator;

	protected TimeSpan FlushTimeout { get; }

	protected int WriteBufferSize { get; }

	public BufferedConnectionInitiator(IConnectionInitiator connectionInitiator, TimeSpan flushTimeout, int writeBufferSize)
	{
		_connectionInitiator = connectionInitiator;
		FlushTimeout = flushTimeout;
		WriteBufferSize = writeBufferSize;
	}

	public IConnection Connect(Uri uri, TimeSpan timeout)
	{
		return new BufferedConnection(_connectionInitiator.Connect(uri, timeout), FlushTimeout, WriteBufferSize);
	}

	public async Task<IConnection> ConnectAsync(Uri uri, TimeSpan timeout)
	{
		return new BufferedConnection(await _connectionInitiator.ConnectAsync(uri, timeout), FlushTimeout, WriteBufferSize);
	}
}
