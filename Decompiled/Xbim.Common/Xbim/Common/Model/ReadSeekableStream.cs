using System;
using System.IO;

namespace Xbim.Common.Model;

public class ReadSeekableStream : Stream
{
	private long _underlyingPosition;

	private readonly byte[] _seekBackBuffer;

	private int _seekBackBufferCount;

	private int _seekBackBufferIndex;

	private readonly Stream _underlyingStream;

	public bool BufferEnabled { get; private set; }

	public override bool CanRead => true;

	public override bool CanSeek => BufferEnabled;

	public override long Position
	{
		get
		{
			return _underlyingPosition - (_seekBackBufferCount - _seekBackBufferIndex);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public override bool CanTimeout => _underlyingStream.CanTimeout;

	public override bool CanWrite => _underlyingStream.CanWrite;

	public override long Length => _underlyingStream.Length;

	public ReadSeekableStream(Stream underlyingStream, int seekBackBufferSize)
	{
		if (!underlyingStream.CanRead)
		{
			throw new Exception($"Provided stream {underlyingStream} is not readable");
		}
		if (underlyingStream.CanSeek)
		{
			throw new Exception($"Provided stream {underlyingStream} is already Seekable, and will not benefit from this wrapper");
		}
		if (underlyingStream == null)
		{
			throw new ArgumentNullException("underlyingStream");
		}
		if (seekBackBufferSize <= 0)
		{
			throw new Exception("Buffer size must be a positive");
		}
		_underlyingStream = underlyingStream;
		_seekBackBuffer = new byte[seekBackBufferSize];
		BufferEnabled = true;
	}

	public void DisableBuffering()
	{
		BufferEnabled = false;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = 0;
		if (_seekBackBufferIndex < _seekBackBufferCount)
		{
			num = Math.Min(count, _seekBackBufferCount - _seekBackBufferIndex);
			Buffer.BlockCopy(_seekBackBuffer, _seekBackBufferIndex, buffer, offset, num);
			offset += num;
			count -= num;
			_seekBackBufferIndex += num;
		}
		int num2 = 0;
		if (count > 0)
		{
			num2 = _underlyingStream.Read(buffer, offset, count);
			if (BufferEnabled && num2 > 0)
			{
				_underlyingPosition += num2;
				int num3 = Math.Min(num2, _seekBackBuffer.Length);
				int num4 = Math.Min(_seekBackBufferCount, _seekBackBuffer.Length - num3);
				int num5 = Math.Min(_seekBackBufferCount - 1, num4);
				if (num5 > 0)
				{
					Buffer.BlockCopy(_seekBackBuffer, _seekBackBufferCount - num5, _seekBackBuffer, 0, num5);
				}
				Buffer.BlockCopy(buffer, offset, _seekBackBuffer, num4, num3);
				_seekBackBufferCount = Math.Min(_seekBackBuffer.Length, _seekBackBufferCount + num3);
				_seekBackBufferIndex = _seekBackBufferCount;
			}
		}
		return num + num2;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (!BufferEnabled)
		{
			throw new NotSupportedException("Cannot seek when back buffer is disabled");
		}
		long num;
		switch (origin)
		{
		case SeekOrigin.End:
			return SeekFromEnd((int)Math.Max(0L, -offset));
		default:
			num = offset - Position;
			break;
		case SeekOrigin.Current:
			num = offset;
			break;
		}
		long num2 = num;
		if (num2 == 0L)
		{
			return Position;
		}
		if (num2 > 0)
		{
			return SeekForward(num2);
		}
		return SeekBackwards(-num2);
	}

	private long SeekForward(long origOffset)
	{
		long num = origOffset;
		int num2 = _seekBackBuffer.Length;
		int num3 = _seekBackBufferCount - _seekBackBufferIndex;
		int num4 = (int)Math.Min(num, num3);
		num -= num4;
		_seekBackBufferIndex += num4;
		if (num > 0)
		{
			if (_seekBackBufferCount < num2)
			{
				int num5 = num2 - _seekBackBufferCount;
				if (num < num5)
				{
					num5 = (int)num;
				}
				int num6 = _underlyingStream.Read(_seekBackBuffer, _seekBackBufferCount, num5);
				_underlyingPosition += num6;
				_seekBackBufferCount += num6;
				_seekBackBufferIndex = _seekBackBufferCount;
				if (num6 < num5)
				{
					if (_seekBackBufferCount < num)
					{
						throw new NotSupportedException("Reached end of stream seeking forward " + origOffset + " bytes");
					}
					return Position;
				}
				num -= num6;
			}
			bool flag = true;
			byte[] array = new byte[num2];
			while (num > 0)
			{
				int num7 = (int)((num < num2) ? num : num2);
				int num8 = _underlyingStream.Read(flag ? array : _seekBackBuffer, 0, num7);
				_underlyingPosition += num8;
				int num9 = num7 - num8;
				num -= num8;
				if (num9 > 0 || num == 0L)
				{
					if (flag)
					{
						if (num8 > 0)
						{
							Buffer.BlockCopy(_seekBackBuffer, num8, _seekBackBuffer, 0, num9);
							Buffer.BlockCopy(array, 0, _seekBackBuffer, num9, num8);
						}
					}
					else
					{
						if (num8 > 0)
						{
							Buffer.BlockCopy(_seekBackBuffer, 0, _seekBackBuffer, num9, num8);
						}
						Buffer.BlockCopy(array, num8, _seekBackBuffer, 0, num9);
					}
					if (num > 0)
					{
						throw new NotSupportedException("Reached end of stream seeking forward " + origOffset + " bytes");
					}
				}
				flag = !flag;
			}
		}
		return Position;
	}

	private long SeekBackwards(long offset)
	{
		int num = (int)offset;
		if (offset > int.MaxValue || num > _seekBackBufferIndex)
		{
			throw new NotSupportedException("Cannot currently seek backwards more than " + _seekBackBufferIndex + " bytes");
		}
		_seekBackBufferIndex -= num;
		return Position;
	}

	private long SeekFromEnd(long offset)
	{
		int num = (int)offset;
		int num2 = _seekBackBuffer.Length;
		if (offset > int.MaxValue || num > num2)
		{
			throw new NotSupportedException("Cannot seek backwards from end more than " + num2 + " bytes");
		}
		if (_seekBackBufferCount < num2)
		{
			int num3 = num2 - _seekBackBufferCount;
			int num4 = _underlyingStream.Read(_seekBackBuffer, _seekBackBufferCount, num3);
			_underlyingPosition += num4;
			_seekBackBufferCount += num4;
			_seekBackBufferIndex = Math.Max(0, _seekBackBufferCount - num);
			if (num4 < num3)
			{
				if (_seekBackBufferCount < num)
				{
					throw new NotSupportedException("Could not seek backwards from end " + num + " bytes");
				}
				return Position;
			}
		}
		else
		{
			_seekBackBufferIndex = _seekBackBufferCount;
		}
		bool flag = true;
		byte[] array = new byte[num2];
		int num5;
		int num6;
		while (true)
		{
			num5 = _underlyingStream.Read(flag ? array : _seekBackBuffer, 0, num2);
			_underlyingPosition += num5;
			num6 = num2 - num5;
			if (num6 > 0)
			{
				break;
			}
			flag = !flag;
		}
		if (flag)
		{
			if (num5 > 0)
			{
				Buffer.BlockCopy(_seekBackBuffer, num5, _seekBackBuffer, 0, num6);
				Buffer.BlockCopy(array, 0, _seekBackBuffer, num6, num5);
			}
		}
		else
		{
			if (num5 > 0)
			{
				Buffer.BlockCopy(_seekBackBuffer, 0, _seekBackBuffer, num6, num5);
			}
			Buffer.BlockCopy(array, num5, _seekBackBuffer, 0, num6);
		}
		_seekBackBufferIndex -= num;
		return Position;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_underlyingStream.Close();
		}
		base.Dispose(disposing);
	}

	public override void SetLength(long value)
	{
		_underlyingStream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		_underlyingStream.Write(buffer, offset, count);
	}

	public override void Flush()
	{
		_underlyingStream.Flush();
	}
}
