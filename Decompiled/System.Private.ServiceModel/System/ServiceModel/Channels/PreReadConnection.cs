using System.Runtime;

namespace System.ServiceModel.Channels;

internal class PreReadConnection : DelegatingConnection
{
	private int _asyncBytesRead;

	private byte[] _preReadData;

	private int _preReadOffset;

	private int _preReadCount;

	public PreReadConnection(IConnection innerConnection, byte[] initialData)
		: this(innerConnection, initialData, 0, initialData.Length)
	{
	}

	public PreReadConnection(IConnection innerConnection, byte[] initialData, int initialOffset, int initialSize)
		: base(innerConnection)
	{
		_preReadData = initialData;
		_preReadOffset = initialOffset;
		_preReadCount = initialSize;
	}

	public void AddPreReadData(byte[] initialData, int initialOffset, int initialSize)
	{
		if (_preReadCount > 0)
		{
			byte[] preReadData = _preReadData;
			_preReadData = Fx.AllocateByteArray(initialSize + _preReadCount);
			Buffer.BlockCopy(preReadData, _preReadOffset, _preReadData, 0, _preReadCount);
			Buffer.BlockCopy(initialData, initialOffset, _preReadData, _preReadCount, initialSize);
			_preReadOffset = 0;
			_preReadCount += initialSize;
		}
		else
		{
			_preReadData = initialData;
			_preReadOffset = initialOffset;
			_preReadCount = initialSize;
		}
	}

	public override int Read(byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		ConnectionUtilities.ValidateBufferBounds(buffer, offset, size);
		if (_preReadCount > 0)
		{
			int num = Math.Min(size, _preReadCount);
			Buffer.BlockCopy(_preReadData, _preReadOffset, buffer, offset, num);
			_preReadOffset += num;
			_preReadCount -= num;
			return num;
		}
		return base.Read(buffer, offset, size, timeout);
	}

	public override AsyncCompletionResult BeginRead(int offset, int size, TimeSpan timeout, Action<object> callback, object state)
	{
		ConnectionUtilities.ValidateBufferBounds(AsyncReadBufferSize, offset, size);
		if (_preReadCount > 0)
		{
			int num = Math.Min(size, _preReadCount);
			Buffer.BlockCopy(_preReadData, _preReadOffset, AsyncReadBuffer, offset, num);
			_preReadOffset += num;
			_preReadCount -= num;
			_asyncBytesRead = num;
			return AsyncCompletionResult.Completed;
		}
		return base.BeginRead(offset, size, timeout, callback, state);
	}

	public override int EndRead()
	{
		if (_asyncBytesRead > 0)
		{
			int asyncBytesRead = _asyncBytesRead;
			_asyncBytesRead = 0;
			return asyncBytesRead;
		}
		return base.EndRead();
	}
}
