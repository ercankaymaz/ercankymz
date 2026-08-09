using System.Runtime;

namespace System.ServiceModel.Channels;

public interface IConnection
{
	byte[] AsyncReadBuffer { get; }

	int AsyncReadBufferSize { get; }

	void Abort();

	void Close(TimeSpan timeout, bool asyncAndLinger);

	AsyncCompletionResult BeginWrite(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, Action<object> callback, object state);

	void EndWrite();

	void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout);

	void Write(byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout, BufferManager bufferManager);

	int Read(byte[] buffer, int offset, int size, TimeSpan timeout);

	AsyncCompletionResult BeginRead(int offset, int size, TimeSpan timeout, Action<object> callback, object state);

	int EndRead();

	object GetCoreTransport();
}
