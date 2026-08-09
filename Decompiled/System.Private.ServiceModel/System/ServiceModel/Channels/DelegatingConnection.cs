using System.Runtime;

namespace System.ServiceModel.Channels;

internal abstract class DelegatingConnection : IConnection
{
	public virtual byte[] AsyncReadBuffer => Connection.AsyncReadBuffer;

	public virtual int AsyncReadBufferSize => Connection.AsyncReadBufferSize;

	protected IConnection Connection { get; }

	protected DelegatingConnection(IConnection connection)
	{
		Connection = connection;
	}

	public virtual void Abort()
	{
		Connection.Abort();
	}

	public virtual void Close(TimeSpan timeout, bool asyncAndLinger)
	{
		Connection.Close(timeout, asyncAndLinger);
	}

	public virtual AsyncCompletionResult BeginWrite(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, Action<object> callback, object state)
	{
		return Connection.BeginWrite(buffer, offset, size, immediate, timeout, callback, state);
	}

	public virtual void EndWrite()
	{
		Connection.EndWrite();
	}

	public virtual void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout)
	{
		Connection.Write(buffer, offset, size, immediate, timeout);
	}

	public virtual void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, BufferManager bufferManager)
	{
		Connection.Write(buffer, offset, size, immediate, timeout, bufferManager);
	}

	public virtual int Read(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		return Connection.Read(buffer, offset, size, timeout);
	}

	public virtual AsyncCompletionResult BeginRead(int offset, int size, TimeSpan timeout, Action<object> callback, object state)
	{
		return Connection.BeginRead(offset, size, timeout, callback, state);
	}

	public virtual int EndRead()
	{
		return Connection.EndRead();
	}

	public virtual object GetCoreTransport()
	{
		return Connection.GetCoreTransport();
	}
}
