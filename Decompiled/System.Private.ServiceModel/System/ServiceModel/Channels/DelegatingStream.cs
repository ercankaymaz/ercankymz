using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public abstract class DelegatingStream : Stream
{
	private bool _disposed;

	protected Stream BaseStream { get; }

	public override bool CanRead => BaseStream.CanRead;

	public override bool CanSeek => BaseStream.CanSeek;

	public override bool CanTimeout => BaseStream.CanTimeout;

	public override bool CanWrite => BaseStream.CanWrite;

	public override long Length => BaseStream.Length;

	public override long Position
	{
		get
		{
			return BaseStream.Position;
		}
		set
		{
			BaseStream.Position = value;
		}
	}

	public override int ReadTimeout
	{
		get
		{
			return BaseStream.ReadTimeout;
		}
		set
		{
			BaseStream.ReadTimeout = value;
		}
	}

	public override int WriteTimeout
	{
		get
		{
			return BaseStream.WriteTimeout;
		}
		set
		{
			BaseStream.WriteTimeout = value;
		}
	}

	protected DelegatingStream(Stream stream)
	{
		BaseStream = stream ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
	}

	protected override void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				BaseStream.Dispose();
			}
			_disposed = true;
		}
		base.Dispose(disposing);
	}

	public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
	{
		return BaseStream.CopyToAsync(destination, bufferSize, cancellationToken);
	}

	public override void Flush()
	{
		BaseStream.Flush();
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		return BaseStream.FlushAsync(cancellationToken);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return BaseStream.Read(buffer, offset, count);
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
	}

	public override int ReadByte()
	{
		return BaseStream.ReadByte();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return BaseStream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		BaseStream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		BaseStream.Write(buffer, offset, count);
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return BaseStream.WriteAsync(buffer, offset, count, cancellationToken);
	}

	public override void WriteByte(byte value)
	{
		BaseStream.WriteByte(value);
	}
}
