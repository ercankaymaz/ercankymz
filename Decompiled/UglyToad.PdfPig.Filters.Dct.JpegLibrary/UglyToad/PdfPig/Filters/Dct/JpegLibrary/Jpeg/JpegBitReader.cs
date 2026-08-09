using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal ref struct JpegBitReader(ReadOnlySequence<byte> data)
{
	private ReadOnlySequence<byte> _data = data;

	private ReadOnlySpan<byte> _firstSpan = default(ReadOnlySpan<byte>);

	private ulong _buffer = 0uL;

	private byte _bitsInBuffer = 0;

	private JpegMarker _nextMarker = (JpegMarker)0;

	public int RemainingBits => 8 * (int)(_data.Length + _firstSpan.Length) + _bitsInBuffer;

	public void AdvanceAlignByte()
	{
		_bitsInBuffer = (byte)(_bitsInBuffer - _bitsInBuffer % 8);
		FillBuffer();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryLoadFirstSpan()
	{
		if (_data.IsEmpty)
		{
			return false;
		}
		_firstSpan = _data.First.Span;
		_data = _data.Slice(_firstSpan.Length);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TryReadNextByte(out byte byteRead)
	{
		if (_firstSpan.IsEmpty && !TryLoadFirstSpan())
		{
			byteRead = 0;
			return false;
		}
		byteRead = _firstSpan[0];
		_firstSpan = _firstSpan.Slice(1);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool TryPeekNextByte(out byte bytePeeked)
	{
		if (_firstSpan.IsEmpty && !TryLoadFirstSpan())
		{
			bytePeeked = 0;
			return false;
		}
		bytePeeked = _firstSpan[0];
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int FillBuffer()
	{
		while (_bitsInBuffer < 32)
		{
			if (_nextMarker != 0)
			{
				return _bitsInBuffer;
			}
			if (!TryReadNextByte(out var byteRead))
			{
				break;
			}
			if (byteRead == byte.MaxValue)
			{
				if (!TryPeekNextByte(out byteRead))
				{
					break;
				}
				if (byteRead == byte.MaxValue)
				{
					continue;
				}
				TryReadNextByte(out var _);
				if (byteRead != 0)
				{
					_nextMarker = (JpegMarker)byteRead;
					break;
				}
				byteRead = byte.MaxValue;
			}
			_buffer = (_buffer << 8) | byteRead;
			_bitsInBuffer += 8;
		}
		return _bitsInBuffer;
	}

	public JpegMarker TryReadMarker()
	{
		if (_bitsInBuffer == 0)
		{
			JpegMarker nextMarker = _nextMarker;
			_nextMarker = (JpegMarker)0;
			return nextMarker;
		}
		return (JpegMarker)0;
	}

	public JpegMarker TryPeekMarker()
	{
		if (_bitsInBuffer != 0)
		{
			return (JpegMarker)0;
		}
		return _nextMarker;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int PeekBits(int length, out int bitsPeeked)
	{
		int num = _bitsInBuffer;
		if (num < length)
		{
			num = FillBuffer();
			if (num < length)
			{
				bitsPeeked = num;
				return (((int)_buffer << length - num) & ((1 << length) - 1)) | ((1 << length - num) - 1);
			}
		}
		int num2 = num - length;
		bitsPeeked = length;
		return (int)(_buffer >> num2) & ((1 << length) - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryAdvanceBits(int length, out bool isMarkerEncountered)
	{
		if (_bitsInBuffer < length && !TryLoadBits(length, out isMarkerEncountered))
		{
			return false;
		}
		_bitsInBuffer = (byte)(_bitsInBuffer - length);
		isMarkerEncountered = false;
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryReadBits(int length, out int bits, out bool isMarkerEncountered)
	{
		if (_bitsInBuffer < length && !TryLoadBits(length, out isMarkerEncountered))
		{
			bits = 0;
			return false;
		}
		_bitsInBuffer = (byte)(_bitsInBuffer - length);
		bits = (int)(_buffer >> (int)_bitsInBuffer) & ((1 << length) - 1);
		isMarkerEncountered = false;
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TryLoadBits(int length, out bool isMarkerEncountered)
	{
		int num = FillBuffer();
		if (num < length)
		{
			isMarkerEncountered = num == 0 && _nextMarker != (JpegMarker)0;
			return false;
		}
		isMarkerEncountered = false;
		return true;
	}
}
