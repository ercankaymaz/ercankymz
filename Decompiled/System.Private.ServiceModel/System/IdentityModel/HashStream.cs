using System.IO;
using System.Security.Cryptography;
using System.ServiceModel;

namespace System.IdentityModel;

internal sealed class HashStream : Stream
{
	private bool _disposed;

	private MemoryStream _logStream;

	public override bool CanRead => false;

	public override bool CanWrite => true;

	public override bool CanSeek => false;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
		}
	}

	public HashStream(HashAlgorithm hash)
	{
		if (hash == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("hash");
		}
		Reset(hash);
	}

	public override void Flush()
	{
	}

	public void FlushHash()
	{
		FlushHash(null);
	}

	public void FlushHash(MemoryStream preCanonicalBytes)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public byte[] FlushHashAndGetValue()
	{
		return FlushHashAndGetValue(null);
	}

	public byte[] FlushHashAndGetValue(MemoryStream preCanonicalBytes)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	public void Reset()
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public void Reset(HashAlgorithm hash)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	public override void SetLength(long length)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (!_disposed)
		{
			if (disposing && _logStream != null)
			{
				_logStream.Dispose();
				_logStream = null;
			}
			_disposed = true;
		}
	}
}
