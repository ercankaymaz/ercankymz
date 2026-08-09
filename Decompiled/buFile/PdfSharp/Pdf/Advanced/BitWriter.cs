using System;

namespace PdfSharp.Pdf.Advanced;

internal class BitWriter
{
	private static readonly uint[] masks = new uint[9] { 0u, 1u, 3u, 7u, 15u, 31u, 63u, 127u, 255u };

	private int _bytesOffsetWrite;

	private readonly byte[] _imageData;

	private uint _buffer;

	private uint _bitsInBuffer;

	internal BitWriter(ref byte[] imageData)
	{
		_imageData = imageData;
	}

	internal void FlushBuffer()
	{
		if (_bitsInBuffer != 0)
		{
			uint bits = 8 - _bitsInBuffer;
			WriteBits(0u, bits);
		}
	}

	internal void WriteBits(uint value, uint bits)
	{
		while (bits + _bitsInBuffer > 8)
		{
			uint num = 8 - _bitsInBuffer;
			uint num2 = bits - num;
			WriteBits(value >> (int)num2, num);
			bits = num2;
		}
		_buffer = (_buffer << (int)bits) + (value & masks[bits]);
		_bitsInBuffer += bits;
		if (_bitsInBuffer == 8)
		{
			_imageData[_bytesOffsetWrite] = (byte)_buffer;
			_bitsInBuffer = 0u;
			_bytesOffsetWrite++;
		}
	}

	internal void WriteTableLine(uint[] table, uint line)
	{
		uint value = table[line * 2];
		uint bits = table[line * 2 + 1];
		WriteBits(value, bits);
	}

	[Obsolete]
	internal void WriteEOL()
	{
		WriteTableLine(PdfImage.WhiteMakeUpCodes, 40u);
	}

	internal int BytesWritten()
	{
		FlushBuffer();
		return _bytesOffsetWrite;
	}
}
