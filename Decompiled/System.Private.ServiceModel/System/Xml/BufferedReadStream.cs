using System.IO;
using System.ServiceModel;

namespace System.Xml;

internal class BufferedReadStream : Stream
{
	private Stream stream;

	private byte[] storedBuffer;

	private int storedLength;

	private int storedOffset;

	private bool readMore;

	public override bool CanWrite => false;

	public override bool CanSeek => false;

	public override bool CanRead => stream.CanRead;

	public override long Length
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SeekNotSupportedOnStream, stream.GetType().FullName)));
		}
	}

	public override long Position
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SeekNotSupportedOnStream, stream.GetType().FullName)));
		}
		set
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SeekNotSupportedOnStream, stream.GetType().FullName)));
		}
	}

	public BufferedReadStream(Stream stream)
		: this(stream, readMore: false)
	{
	}

	public BufferedReadStream(Stream stream, bool readMore)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		this.stream = stream;
		this.readMore = readMore;
	}

	public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
	{
		if (!CanRead)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.ReadNotSupportedOnStream, stream.GetType().FullName)));
		}
		return stream.BeginRead(buffer, offset, count, callback, state);
	}

	public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.WriteNotSupportedOnStream, stream.GetType().FullName)));
	}

	public override void Close()
	{
		stream.Close();
	}

	public override int EndRead(IAsyncResult asyncResult)
	{
		if (!CanRead)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.ReadNotSupportedOnStream, stream.GetType().FullName)));
		}
		return stream.EndRead(asyncResult);
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.WriteNotSupportedOnStream, stream.GetType().FullName)));
	}

	public override void Flush()
	{
		stream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (!CanRead)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.ReadNotSupportedOnStream, stream.GetType().FullName)));
		}
		if (buffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
		}
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
		}
		if (offset > buffer.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.Format(System.SR.OffsetExceedsBufferSize, buffer.Length)));
		}
		if (count < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.ValueMustBeNonNegative));
		}
		if (count > buffer.Length - offset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, buffer.Length - offset)));
		}
		int num = 0;
		if (storedOffset < storedLength)
		{
			num = Math.Min(count, storedLength - storedOffset);
			Buffer.BlockCopy(storedBuffer, storedOffset, buffer, offset, num);
			storedOffset += num;
			if (num == count || !readMore)
			{
				return num;
			}
			offset += num;
			count -= num;
		}
		return num + stream.Read(buffer, offset, count);
	}

	public override int ReadByte()
	{
		if (storedOffset < storedLength)
		{
			return storedBuffer[storedOffset++];
		}
		return base.ReadByte();
	}

	public int ReadBlock(byte[] buffer, int offset, int count)
	{
		int i;
		int num;
		for (i = 0; i < count; i += num)
		{
			if ((num = Read(buffer, offset + i, count - i)) == 0)
			{
				break;
			}
		}
		return i;
	}

	public void Push(byte[] buffer, int offset, int count)
	{
		if (count == 0)
		{
			return;
		}
		if (storedOffset == storedLength)
		{
			if (storedBuffer == null || storedBuffer.Length < count)
			{
				storedBuffer = new byte[count];
			}
			storedOffset = 0;
			storedLength = count;
		}
		else if (count <= storedOffset)
		{
			storedOffset -= count;
		}
		else if (count <= storedBuffer.Length - storedLength + storedOffset)
		{
			Buffer.BlockCopy(storedBuffer, storedOffset, storedBuffer, count, storedLength - storedOffset);
			storedLength += count - storedOffset;
			storedOffset = 0;
		}
		else
		{
			byte[] dst = new byte[count + storedLength - storedOffset];
			Buffer.BlockCopy(storedBuffer, storedOffset, dst, count, storedLength - storedOffset);
			storedLength += count - storedOffset;
			storedOffset = 0;
			storedBuffer = dst;
		}
		Buffer.BlockCopy(buffer, offset, storedBuffer, storedOffset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SeekNotSupportedOnStream, stream.GetType().FullName)));
	}

	public override void SetLength(long value)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SeekNotSupportedOnStream, stream.GetType().FullName)));
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.WriteNotSupportedOnStream, stream.GetType().FullName)));
	}
}
