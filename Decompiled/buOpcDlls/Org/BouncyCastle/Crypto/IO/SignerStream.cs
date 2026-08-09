using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.IO;

namespace Org.BouncyCastle.Crypto.IO;

public sealed class SignerStream : Stream
{
	private readonly Stream m_stream;

	private readonly ISigner m_readSigner;

	private readonly ISigner m_writeSigner;

	public ISigner ReadSigner => m_readSigner;

	public ISigner WriteSigner => m_writeSigner;

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
			if (m_readSigner != null)
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
			if (m_writeSigner != null)
			{
				return this;
			}
			return m_stream;
		}
	}

	public SignerStream(Stream stream, ISigner readSigner, ISigner writeSigner)
	{
		m_stream = stream;
		m_readSigner = readSigner;
		m_writeSigner = writeSigner;
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
		if (m_readSigner != null && num > 0)
		{
			m_readSigner.BlockUpdate(buffer, offset, num);
		}
		return num;
	}

	public override int ReadByte()
	{
		int num = m_stream.ReadByte();
		if (m_readSigner != null && num >= 0)
		{
			m_readSigner.Update((byte)num);
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
		if (m_writeSigner != null && count > 0)
		{
			m_writeSigner.BlockUpdate(buffer, offset, count);
		}
	}

	public override void WriteByte(byte value)
	{
		m_stream.WriteByte(value);
		if (m_writeSigner != null)
		{
			m_writeSigner.Update(value);
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
