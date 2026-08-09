using System;
using System.Buffers;
using System.Buffers.Binary;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal ref struct JpegWriter(IBufferWriter<byte> writer, int minimumBufferSize)
{
	private readonly IBufferWriter<byte> _writer = writer;

	private readonly int _minimumBufferSize = minimumBufferSize;

	private Span<byte> _buffer = default(Span<byte>);

	private int _bufferConsunmed = 0;

	private ulong _register = 0uL;

	private bool _bitMode = false;

	private byte _bitsInRegister = 0;

	private void EnsureBuffer()
	{
		if (_writer == null)
		{
			throw new InvalidOperationException("Writer is not initialized.");
		}
		if (_buffer.IsEmpty)
		{
			Flush();
			_buffer = _writer.GetSpan();
		}
	}

	private void EnsureBuffer(int byteCount)
	{
		if (_writer == null)
		{
			throw new InvalidOperationException("Writer is not initialized.");
		}
		if (_buffer.Length < byteCount)
		{
			Flush();
			_buffer = _writer.GetSpan(Math.Max(_minimumBufferSize, byteCount));
		}
	}

	public void Flush()
	{
		if (_writer == null)
		{
			throw new InvalidOperationException("Writer is not initialized.");
		}
		FlushBuffer();
		if (_bitMode)
		{
			if (_buffer.Length < 16)
			{
				_buffer = _writer.GetSpan(Math.Max(_minimumBufferSize, 16));
			}
			FlushRegister();
		}
	}

	private void FlushBuffer()
	{
		if (_bufferConsunmed != 0)
		{
			_writer.Advance(_bufferConsunmed);
		}
		_bufferConsunmed = 0;
	}

	private void FlushRegister()
	{
		while (_bitsInRegister >= 8)
		{
			byte b = (byte)(_register >> 56);
			_register <<= 8;
			_bitsInRegister -= 8;
			if (b == byte.MaxValue)
			{
				_buffer[1] = 0;
				_buffer[0] = byte.MaxValue;
				_buffer = _buffer.Slice(2);
				_bufferConsunmed += 2;
			}
			else
			{
				_buffer[0] = b;
				_buffer = _buffer.Slice(1);
				_bufferConsunmed++;
			}
		}
	}

	public void EnterBitMode()
	{
		_bitMode = true;
	}

	public void ExitBitMode()
	{
		if (!_bitMode)
		{
			return;
		}
		Flush();
		if (_bitsInRegister > 0)
		{
			_register |= (ulong)((1L << 8 - _bitsInRegister) - 1 << 56);
			_bitsInRegister = 8;
			if (_buffer.Length < 16)
			{
				if (_bufferConsunmed != 0)
				{
					_writer.Advance(_bufferConsunmed);
				}
				_buffer = _writer.GetSpan(Math.Max(_minimumBufferSize, 16));
			}
			FlushRegister();
		}
		_bitMode = false;
	}

	public Span<byte> GetSpan(int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (_bitMode)
		{
			throw new InvalidOperationException();
		}
		EnsureBuffer(length);
		return _buffer.Slice(0, length);
	}

	public void Advance(int length)
	{
		if ((uint)length > (uint)_buffer.Length)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		_buffer = _buffer.Slice(length);
		_bufferConsunmed += length;
	}

	public void WriteBits(uint bits, int bitLength)
	{
		if ((uint)bitLength > 32u)
		{
			throw new ArgumentOutOfRangeException("bitLength");
		}
		if (!_bitMode)
		{
			throw new InvalidOperationException("Bit mode is not enabled.");
		}
		if (_bitsInRegister > 32)
		{
			Flush();
		}
		ulong num = (ulong)bits << 64 - _bitsInRegister - bitLength;
		_register |= num;
		_bitsInRegister += (byte)bitLength;
	}

	public void WriteBytes(ReadOnlySequence<byte> bytes)
	{
		if (_bitMode)
		{
			throw new InvalidOperationException("When bit mode is enabled, you are not allowed to write bytes to the stream.");
		}
		while (!bytes.IsEmpty)
		{
			ReadOnlySpan<byte> readOnlySpan = bytes.First.Span;
			bytes = bytes.Slice(readOnlySpan.Length);
			while (!readOnlySpan.IsEmpty)
			{
				EnsureBuffer();
				int num = Math.Min(_buffer.Length, readOnlySpan.Length);
				readOnlySpan.Slice(0, num).CopyTo(_buffer);
				readOnlySpan = readOnlySpan.Slice(num);
				_buffer = _buffer.Slice(num);
				_bufferConsunmed += num;
			}
		}
	}

	public void WriteBytes(ReadOnlySpan<byte> bytes)
	{
		if (_bitMode)
		{
			throw new InvalidOperationException("When bit mode is enabled, you are not allowed to write bytes to the stream.");
		}
		while (!bytes.IsEmpty)
		{
			EnsureBuffer();
			int num = Math.Min(_buffer.Length, bytes.Length);
			bytes.Slice(0, num).CopyTo(_buffer);
			bytes = bytes.Slice(num);
			_buffer = _buffer.Slice(num);
			_bufferConsunmed += num;
		}
	}

	public void WriteMarker(JpegMarker marker)
	{
		if (_bitMode)
		{
			throw new InvalidOperationException("When bit mode is enabled, you are not allowed to write bytes to the stream.");
		}
		EnsureBuffer(2);
		Span<byte> buffer = _buffer;
		buffer[1] = (byte)marker;
		buffer[0] = byte.MaxValue;
		_buffer = buffer.Slice(2);
		_bufferConsunmed += 2;
	}

	public void WriteLength(ushort length)
	{
		if (_bitMode)
		{
			throw new InvalidOperationException("When bit mode is enabled, you are not allowed to write bytes to the stream.");
		}
		EnsureBuffer(2);
		BinaryPrimitives.WriteUInt16BigEndian(_buffer, (ushort)(length + 2));
		_buffer = _buffer.Slice(2);
		_bufferConsunmed += 2;
	}
}
