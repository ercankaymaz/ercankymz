using System.IO;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class TimeoutStream : DelegatingStream
{
	private TimeoutHelper _timeoutHelper;

	private bool _disposed;

	private byte[] _oneByteArray = new byte[1];

	public TimeoutStream(Stream stream, TimeSpan timeout)
		: base(stream)
	{
		if (!stream.CanTimeout)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("stream", System.SR.StreamDoesNotSupportTimeout);
		}
		_timeoutHelper = new TimeoutHelper(timeout);
		ReadTimeout = TimeoutHelper.ToMilliseconds(timeout);
		WriteTimeout = ReadTimeout;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return ReadAsyncInternal(buffer, offset, count, CancellationToken.None).WaitForCompletion();
	}

	public override int ReadByte()
	{
		if (Read(_oneByteArray, 0, 1) == 0)
		{
			return -1;
		}
		return _oneByteArray[0];
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return await base.ReadAsync(buffer, offset, count, await _timeoutHelper.GetCancellationTokenAsync());
	}

	private async Task<int> ReadAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		return await ReadAsync(buffer, offset, count, cancellationToken);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		WriteAsyncInternal(buffer, offset, count, CancellationToken.None).WaitForCompletion();
	}

	public override void WriteByte(byte value)
	{
		_oneByteArray[0] = value;
		Write(_oneByteArray, 0, 1);
	}

	public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		await base.WriteAsync(buffer, offset, count, await _timeoutHelper.GetCancellationTokenAsync());
	}

	private async Task WriteAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		await TaskHelpers.EnsureDefaultTaskScheduler();
		await WriteAsync(buffer, offset, count, cancellationToken);
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				_timeoutHelper = default(TimeoutHelper);
			}
			_disposed = true;
		}
		base.Dispose(disposing);
	}
}
