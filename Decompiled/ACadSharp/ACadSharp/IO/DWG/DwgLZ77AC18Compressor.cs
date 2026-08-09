using System;
using System.IO;

namespace ACadSharp.IO.DWG;

internal class DwgLZ77AC18Compressor : ICompressor
{
	private byte[] _source;

	private Stream _dest;

	private int[] _block = new int[32768];

	private int _initialOffset;

	private int _currPosition;

	private int _currOffset;

	private int _totalOffset;

	public void Compress(byte[] source, int offset, int totalSize, Stream dest)
	{
		restartBlock();
		_source = source;
		_dest = dest;
		_initialOffset = offset;
		_totalOffset = _initialOffset + totalSize;
		_currOffset = _initialOffset;
		_currPosition = _initialOffset + 4;
		int num = 0;
		int matchPosition = 0;
		int offset2 = 0;
		int matchPos = 0;
		while (_currPosition < _totalOffset - 19)
		{
			if (!compressChunk(ref offset2, ref matchPos))
			{
				_currPosition++;
				continue;
			}
			int num2 = _currPosition - _currOffset;
			if (num != 0)
			{
				applyMask(matchPosition, num, num2);
			}
			writeLiteralLength(num2);
			_currPosition += offset2;
			_currOffset = _currPosition;
			num = offset2;
			matchPosition = matchPos;
		}
		int num3 = _totalOffset - _currOffset;
		if (num != 0)
		{
			applyMask(matchPosition, num, num3);
		}
		writeLiteralLength(num3);
		dest.WriteByte(17);
		dest.WriteByte(0);
		dest.WriteByte(0);
	}

	private void restartBlock()
	{
		for (int num = _block.Length - 1; num >= 0; num--)
		{
			_block[num] = -1;
		}
	}

	private void writeLen(int len)
	{
		if (len <= 0)
		{
			throw new ArgumentException();
		}
		while (len > 255)
		{
			len -= 255;
			_dest.WriteByte(0);
		}
		_dest.WriteByte((byte)len);
	}

	private void writeOpCode(int opCode, int compressionOffset, int value)
	{
		if (compressionOffset <= 0)
		{
			throw new ArgumentException();
		}
		if (value <= 0)
		{
			throw new ArgumentException();
		}
		if (compressionOffset <= value)
		{
			opCode |= compressionOffset - 2;
			_dest.WriteByte((byte)opCode);
		}
		else
		{
			_dest.WriteByte((byte)opCode);
			writeLen(compressionOffset - value);
		}
	}

	private void writeLiteralLength(int length)
	{
		if (length > 0)
		{
			if (length > 3)
			{
				writeOpCode(0, length - 1, 17);
			}
			int num = _currOffset;
			for (int i = 0; i < length; i++)
			{
				_dest.WriteByte(_source[num]);
				num++;
			}
		}
	}

	private void applyMask(int matchPosition, int compressionOffset, int mask)
	{
		int num = 0;
		int num2 = 0;
		if (compressionOffset >= 15 || matchPosition > 1024)
		{
			if (matchPosition <= 16384)
			{
				matchPosition--;
				writeOpCode(32, compressionOffset, 33);
			}
			else
			{
				matchPosition -= 16384;
				writeOpCode(0x10 | ((matchPosition >> 11) & 8), compressionOffset, 9);
			}
			num = (matchPosition & 0xFF) << 2;
			num2 = matchPosition >> 6;
		}
		else
		{
			matchPosition--;
			num = (compressionOffset + 1 << 4) | ((matchPosition & 3) << 2);
			num2 = matchPosition >> 2;
		}
		if (mask < 4)
		{
			num |= mask;
		}
		_dest.WriteByte((byte)num);
		_dest.WriteByte((byte)num2);
	}

	private bool compressChunk(ref int offset, ref int matchPos)
	{
		offset = 0;
		int num = (((((_source[_currPosition + 3] << 6) ^ _source[_currPosition + 2]) << 5) ^ _source[_currPosition + 1]) << 5) ^ _source[_currPosition];
		int num2 = (num + (num >> 5)) & 0x7FFF;
		int num3 = _block[num2];
		matchPos = _currPosition - num3;
		if (num3 >= _initialOffset && matchPos <= 49151)
		{
			if (matchPos > 1024 && _source[_currPosition + 3] != _source[num3 + 3])
			{
				num2 = (num2 & 0x7FF) ^ 0x401F;
				num3 = _block[num2];
				matchPos = _currPosition - num3;
				if (num3 < _initialOffset || matchPos > 49151 || (matchPos > 1024 && _source[_currPosition + 3] != _source[num3 + 3]))
				{
					_block[num2] = _currPosition;
					return false;
				}
			}
			if (_source[_currPosition] == _source[num3] && _source[_currPosition + 1] == _source[num3 + 1] && _source[_currPosition + 2] == _source[num3 + 2])
			{
				offset = 3;
				int num4 = num3 + 3;
				int num5 = _currPosition + 3;
				while (num5 < _totalOffset && _source[num4++] == _source[num5++])
				{
					offset++;
				}
			}
		}
		_block[num2] = _currPosition;
		return offset >= 3;
	}
}
