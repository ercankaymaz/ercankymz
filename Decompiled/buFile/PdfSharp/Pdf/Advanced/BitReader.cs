#define DEBUG
using System.Diagnostics;

namespace PdfSharp.Pdf.Advanced;

internal class BitReader
{
	private readonly byte[] _imageBits;

	private uint _bytesOffsetRead;

	private readonly uint _bytesFileOffset;

	private byte _buffer;

	private uint _bitsInBuffer;

	private readonly uint _bitsTotal;

	internal BitReader(byte[] imageBits, uint bytesFileOffset, uint bits)
	{
		_imageBits = imageBits;
		_bytesFileOffset = bytesFileOffset;
		_bitsTotal = bits;
		_bytesOffsetRead = bytesFileOffset;
		_buffer = imageBits[_bytesOffsetRead];
		_bitsInBuffer = 8u;
	}

	internal void SetPosition(uint position)
	{
		_bytesOffsetRead = _bytesFileOffset + (position >> 3);
		_buffer = _imageBits[_bytesOffsetRead];
		_bitsInBuffer = 8 - (position & 7);
	}

	internal bool GetBit(uint position)
	{
		if (position >= _bitsTotal)
		{
			return false;
		}
		SetPosition(position);
		uint bits;
		return (PeekByte(out bits) & 0x80) > 0;
	}

	internal byte PeekByte(out uint bits)
	{
		if (_bitsInBuffer == 8)
		{
			bits = 8u;
			return _buffer;
		}
		bits = _bitsInBuffer;
		return (byte)(_buffer << (int)(8 - _bitsInBuffer));
	}

	internal void NextByte()
	{
		_buffer = _imageBits[++_bytesOffsetRead];
		_bitsInBuffer = 8u;
	}

	internal void SkipBits(uint bits)
	{
		Debug.Assert(bits <= _bitsInBuffer, "Buffer underrun");
		if (bits == _bitsInBuffer)
		{
			NextByte();
		}
		else
		{
			_bitsInBuffer -= bits;
		}
	}
}
