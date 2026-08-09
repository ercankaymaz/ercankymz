using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Crypto.IO;

public sealed class MacStream : Stream
{
	private readonly Stream m_stream;

	private readonly IMac m_readMac;

	private readonly IMac m_writeMac;

	public IMac ReadMac => m_readMac;

	public IMac WriteMac => m_writeMac;

	public override bool CanRead => m_stream.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => m_stream.CanWrite;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	private Stream ReadSource
	{
		get
		{
			if (m_readMac != null)
			{
				return this;
			}
			return m_stream;
		}
	}

	private Stream WriteDestination
	{
		get
		{
			if (m_writeMac != null)
			{
				return this;
			}
			return m_stream;
		}
	}

	public MacStream(Stream stream, IMac readMac, IMac writeMac)
	{
		m_stream = stream;
		m_readMac = readMac;
		m_writeMac = writeMac;
	}

	public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
	{
		return Streams.CopyToAsync(ReadSource, destination, bufferSize, cancellationToken);
	}

	public override void Flush()
	{
		m_stream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = m_stream.Read(buffer, offset, count);
		if (m_readMac != null && num > 0)
		{
			m_readMac.BlockUpdate(buffer, offset, num);
		}
		return num;
	}

	public override int ReadByte()
	{
		int num = m_stream.ReadByte();
		if (m_readMac != null && num >= 0)
		{
			m_readMac.Update((byte)num);
		}
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long length)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		m_stream.Write(buffer, offset, count);
		if (m_writeMac != null && count > 0)
		{
			m_writeMac.BlockUpdate(buffer, offset, count);
		}
	}

	public override void WriteByte(byte value)
	{
		m_stream.WriteByte(value);
		if (m_writeMac != null)
		{
			m_writeMac.Update(value);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			m_stream.Dispose();
		}
		base.Dispose(disposing);
	}
}
