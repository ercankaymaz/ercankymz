using System.IO;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public class MaxMessageSizeStream : DelegatingStream
{
	private long _maxMessageSize;

	private long _totalBytesRead;

	private long _bytesWritten;

	public MaxMessageSizeStream(Stream stream, long maxMessageSize)
		: base(stream)
	{
		_maxMessageSize = maxMessageSize;
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		count = PrepareRead(count);
		return FinishRead(await base.ReadAsync(buffer, offset, count, cancellationToken));
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		PrepareWrite(count);
		return base.WriteAsync(buffer, offset, count, cancellationToken);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		count = PrepareRead(count);
		return FinishRead(base.Read(buffer, offset, count));
	}

	public override int ReadByte()
	{
		PrepareRead(1);
		int num = base.ReadByte();
		if (num != -1)
		{
			FinishRead(1);
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		PrepareWrite(count);
		base.Write(buffer, offset, count);
	}

	public override void WriteByte(byte value)
	{
		PrepareWrite(1);
		base.WriteByte(value);
	}

	public static Exception CreateMaxReceivedMessageSizeExceededException(long maxMessageSize)
	{
		string text = System.SR.Format(System.SR.MaxReceivedMessageSizeExceeded, maxMessageSize);
		Exception innerException = new QuotaExceededException(text);
		if (WcfEventSource.Instance.MaxReceivedMessageSizeExceededIsEnabled())
		{
			WcfEventSource.Instance.MaxReceivedMessageSizeExceeded(text);
		}
		return new CommunicationException(text, innerException);
	}

	internal static Exception CreateMaxSentMessageSizeExceededException(long maxMessageSize)
	{
		string text = System.SR.Format(System.SR.MaxSentMessageSizeExceeded, maxMessageSize);
		Exception innerException = new QuotaExceededException(text);
		if (WcfEventSource.Instance.MaxSentMessageSizeExceededIsEnabled())
		{
			WcfEventSource.Instance.MaxSentMessageSizeExceeded(text);
		}
		return new CommunicationException(text, innerException);
	}

	private int PrepareRead(int bytesToRead)
	{
		if (_totalBytesRead >= _maxMessageSize)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateMaxReceivedMessageSizeExceededException(_maxMessageSize));
		}
		long num = _maxMessageSize - _totalBytesRead;
		if (num > int.MaxValue)
		{
			return bytesToRead;
		}
		return Math.Min(bytesToRead, (int)(_maxMessageSize - _totalBytesRead));
	}

	private int FinishRead(int bytesRead)
	{
		_totalBytesRead += bytesRead;
		return bytesRead;
	}

	private void PrepareWrite(int bytesToWrite)
	{
		if (_bytesWritten + bytesToWrite > _maxMessageSize)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateMaxSentMessageSizeExceededException(_maxMessageSize));
		}
		_bytesWritten += bytesToWrite;
	}
}
